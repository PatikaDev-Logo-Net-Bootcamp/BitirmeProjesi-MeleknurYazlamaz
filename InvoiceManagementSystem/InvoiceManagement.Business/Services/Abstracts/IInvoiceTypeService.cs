using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Concretes;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IInvoiceTypeService
    {
        IResult Create(InvoiceType entity);
        IResult Delete(int id);
        IResult Update(int id, InvoiceType entity);
        IDataResult<InvoiceType> GetById(int id);
        IDataResult<IEnumerable<InvoiceType>> GetAll();
    }
}
