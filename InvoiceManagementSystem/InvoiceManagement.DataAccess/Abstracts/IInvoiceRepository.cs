using InvoiceManagement.Core.DataAccess;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using System.Collections.Generic;

namespace InvoiceManagement.DataAccess.Abstracts

{
    public interface IInvoiceRepository : IEntityRepository<Invoice>
    {
        IEnumerable<InvoiceDto> GetAllInvoiceDetail();
        IEnumerable<InvoiceDto> GetAllUserInvoiceDetail(int userId);
        InvoiceDto GetInvoiceDetail(int id);
    }
}
