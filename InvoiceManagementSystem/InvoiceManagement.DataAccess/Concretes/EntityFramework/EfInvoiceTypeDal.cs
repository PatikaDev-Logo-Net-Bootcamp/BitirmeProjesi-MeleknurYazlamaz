using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Core.DataAccess.EntityFramework;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfInvoiceTypeDal : EfEntityRepositoryBase<InvoiceType, InvoiceManagementDbContext>, IInvoiceTypeRespository
    {
        public EfInvoiceTypeDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
