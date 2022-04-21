using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Concretes;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IApartmentService
    {
        IResult Create(Apartment entity);
        IResult Delete(int id);
        IResult Update(int id, Apartment entity);
        IDataResult<Apartment> GetById(int id);
        IDataResult<IEnumerable<Apartment>> GetAll();
    }
}
