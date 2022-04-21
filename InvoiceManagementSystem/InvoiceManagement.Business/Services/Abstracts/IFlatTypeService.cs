using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Concretes;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IFlatTypeService
    {
        IResult Create(FlatType entity);
        IResult Delete(int id);
        IResult Update(int id, FlatType entity);
        IDataResult<FlatType> GetById(int id);
        IDataResult<IEnumerable<FlatType>> GetAll();
    }
}
