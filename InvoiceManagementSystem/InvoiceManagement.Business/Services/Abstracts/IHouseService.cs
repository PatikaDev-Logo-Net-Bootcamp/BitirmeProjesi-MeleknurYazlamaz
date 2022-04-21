using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IHouseService 
    {
        IResult Create(House entity);
        IResult Delete(int id);
        IResult Update(int id, House entity);
        IDataResult<House> GetById(int id);
        IDataResult<IEnumerable<House>> GetAll();
        IDataResult<IEnumerable<HouseDto>> GetAllHouseDetail();
        IDataResult<HouseDto> GetHouseDetail(int id);

    }
}
