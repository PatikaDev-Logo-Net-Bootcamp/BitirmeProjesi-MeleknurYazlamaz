using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Dtos;
using System;
using System.Collections.Generic;


namespace InvoiceManagement.Business.Services.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IResult Create(User user)
        {
            _userRepository.Add(user);
            int result = _userRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt Başarısız!", false);
            return new Result("Kayıt Başarılı!", true);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(int id, User entity)
        {
            User user = _userRepository.Get(x => x.Id == id);
            if (user is null)
                return new Result("Kullanıcı bulunamadı", false);
            user.Email = entity.Email==default ? user.Email : entity.Email;
            user.CitizenId = entity.CitizenId == default ? user.CitizenId : entity.CitizenId;
            user.FullName = entity.FullName == default ? user.FullName : entity.FullName;
            user.PhoneNumber = entity.PhoneNumber == default ? user.PhoneNumber : entity.PhoneNumber;
            user.IsActive = entity.IsActive == default ? user.IsActive : entity.IsActive;
            var result = _userRepository.SaveChanges();
            if (result == 0)
                return new Result("Güncelleme Başarısız!", false);
            return new Result("Güncelleme Başarılı!", true);
        }

        public IDataResult<User> GetById(int id)
        {
            User user = _userRepository.Get(x => x.Id == id);
            if (user is null)
                return new DataResult<User>(null, "Kullanıcı bulunamadı!", false);
            return new DataResult<User>(user, true);
        }

        public IDataResult<UserDto> GetByIdUser(int id)
        {
            User user = _userRepository.Get(x => x.Id == id);
            if (user is null)
                return new DataResult<UserDto>(null, "Kullanıcı bulunamadı!", false);
            UserDto rtnObj = _mapper.Map<UserDto>(user);
            return new DataResult<UserDto>(rtnObj, true);
        }

        public IResult AddRefreshToken(int id,string refreshToken, DateTime expirationTime)
        {
            var user = _userRepository.Get(x => x.Id == id);
            user.RefreshToken = refreshToken;
            user.RefresTokenExpireDate = expirationTime;
            int result = _userRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt Başarısız!", false);
            return new Result("Kayıt Başarılı!", true);
        }

        public IDataResult<IEnumerable<User>> GetAll()
        {
            var data = _userRepository.GetList();
            return new DataResult<IEnumerable<User>>(data, true);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            User user = _userRepository.Get(x => x.Email == email);
            if (user is null)
                return new DataResult<User>(null, "Kullanıcı bulunamadı!", false);
            return new DataResult<User>(user,true);
        }

        public IDataResult<UserDto> GetByEmailUser(string email)
        {
            User user = _userRepository.Get(x => x.Email == email);
            if (user is null)
                return new DataResult<UserDto>(null, "Kullanıcı bulunamadı!", false);
            UserDto rtnObj = _mapper.Map<UserDto>(user);
            return new DataResult<UserDto>(rtnObj, true);
        }

        public IDataResult<IEnumerable<UserDto>> GetAllUser()
        {
            var data = _userRepository.GetList();
            var rtnObj = _mapper.Map<IEnumerable<UserDto>>(data);
            return new DataResult<IEnumerable<UserDto>>(rtnObj, true);
        }
    }
}
