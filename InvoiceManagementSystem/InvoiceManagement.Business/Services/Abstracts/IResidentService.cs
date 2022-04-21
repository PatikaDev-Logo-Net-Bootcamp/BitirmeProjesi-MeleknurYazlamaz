using InvoiceManagement.Core.Business.Services;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IResidentService : IBaseCrudService<Resident>
    {
        IDataResult<IEnumerable<ResidentDto>> GetAllDetails();
    }
}
