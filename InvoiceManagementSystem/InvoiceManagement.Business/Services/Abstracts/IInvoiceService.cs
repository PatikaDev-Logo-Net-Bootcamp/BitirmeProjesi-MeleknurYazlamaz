using InvoiceManagement.Core.Business.Services;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IInvoiceService : IBaseCrudService<Invoice>
    {
        IDataResult<IEnumerable<InvoiceDto>> GetAllDetails();

        IDataResult<IEnumerable<InvoiceDto>> GetAllUserInvoiceDetail(int userId);
        IDataResult<InvoiceDto> GetByIdDetail(int id);
        IResult PaySuccess(int id);
    }
}
