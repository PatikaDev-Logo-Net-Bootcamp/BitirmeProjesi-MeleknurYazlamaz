using InvoiceManagement.Core.Business.Services;
using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Dtos;
using System;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IUserService : IBaseCrudService<User>
    {
        IDataResult<UserDto> GetByIdUser(int id);
        IDataResult<User> GetByEmail(string email);
        IDataResult<UserDto> GetByEmailUser(string email);
        IDataResult<IEnumerable<UserDto>> GetAllUser();
        IResult AddRefreshToken(int id ,string refreshToken , DateTime expirationTime);

    }
}