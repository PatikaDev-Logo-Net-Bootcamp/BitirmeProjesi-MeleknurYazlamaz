using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Core.Utilities.Hashing;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Core.Utilities.TokenOperations;
using InvoiceManagement.Core.Utilities.TokenOperations.Models;
using InvoiceManagement.Entities.Dtos;
using Microsoft.Extensions.Configuration;

namespace InvoiceManagement.Business.Services.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthManager(IUserService userService,IConfiguration configuration)
        {
            _userService = userService; 
            _configuration = configuration;
        }

        public IResult RegisterUser(RegisterDto registerUser)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            var user = _userService.GetByEmail(registerUser.Email).Data;
            if (!(user == null))
                return new Result("Kullanıcı zaten mevcut!", false);
            HashingHelper.CreatePasswordHash(registerUser.Password,out passwordSalt, out passwordHash);
            user = new User
            {
                FullName = registerUser.FullName,
                Email = registerUser.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

            };
            var result = _userService.Create(user);
            if (!result.Success)
                return new Result("Kayıt Başarısız!", false);
            return new Result("Kayıt Başarılı!", true);

        }

        public IDataResult<Token> LoginUser(LoginDto loginUser)
        {
            var user = _userService.GetByEmail(loginUser.Email).Data;
            if (user is null)
                return new DataResult<Token>(null,"Kullanıcı bulunamadı!", false);
            if (!HashingHelper.VerifyPasswordHash(loginUser.Password,user.PasswordSalt, user.PasswordHash))
                return new DataResult<Token>(null,"Şifre hatalı! Lütfen tekrar deneyiniz.", false);
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);
            _userService.AddRefreshToken(user.Id, token.RefreshToken, token.Expiration.AddMinutes(5));
            return new DataResult<Token>(token,true);
        }

        public IDataResult<UserDto> GetUserDtoByEmail(string email)
        {
            var result = _userService.GetByEmailUser(email);
            if (!result.Success)
                return new DataResult<UserDto>(null, "Kullanıcı bulunamadı!", false);
            return result;
        }
    }
}
