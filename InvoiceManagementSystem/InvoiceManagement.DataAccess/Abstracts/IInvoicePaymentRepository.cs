using InvoiceManagement.Core.DataAccess;
using InvoiceManagement.Entities.Concretes;

namespace InvoiceManagement.DataAccess.Abstracts
{
    public interface IInvoicePaymentRepository : IEntityRepository<InvoicePayment>
    {
    }
}
