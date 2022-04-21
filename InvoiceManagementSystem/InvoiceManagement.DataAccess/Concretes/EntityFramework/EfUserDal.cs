using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Core.DataAccess.EntityFramework;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, InvoiceManagementDbContext>, IUserRepository
    {
        public EfUserDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
