using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Core.DataAccess.EntityFramework;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfInvoicePaymentDal : EfEntityRepositoryBase<InvoicePayment,InvoiceManagementDbContext> , IInvoicePaymentRepository
    {
        public EfInvoicePaymentDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
