using InvoiceManagement.Core.Utilities.Results;
using System.Collections.Generic;

namespace InvoiceManagement.Core.Business.Services
{
    public interface IBaseCrudService<T>
    {
        IResult Create(T entity);
        IResult Delete(int id);
        IResult Update(int id, T entity);
        IDataResult<T> GetById(int id);
        IDataResult<IEnumerable<T>> GetAll();
    }
}
