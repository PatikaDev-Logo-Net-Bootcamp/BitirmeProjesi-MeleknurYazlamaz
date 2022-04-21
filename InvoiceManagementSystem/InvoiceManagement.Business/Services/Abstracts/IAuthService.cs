using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Core.Utilities.TokenOperations.Models;
using InvoiceManagement.Entities.Dtos;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IAuthService
    {
        IResult RegisterUser(RegisterDto registerUser);
        IDataResult<Token> LoginUser(LoginDto loginUser);
        IDataResult<UserDto> GetUserDtoByEmail(string email);
    }
}
