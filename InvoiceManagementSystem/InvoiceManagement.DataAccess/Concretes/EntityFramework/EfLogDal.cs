using InvoiceManagement.Core.Logging;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Core.DataAccess.EntityFramework;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfLogDal : EfEntityRepositoryBase<Log,InvoiceManagementDbContext> , ILogRepository
    {
        public EfLogDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
