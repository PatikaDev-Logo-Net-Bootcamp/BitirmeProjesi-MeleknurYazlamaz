using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Core.DataAccess.EntityFramework;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfFlatTypeDal : EfEntityRepositoryBase<FlatType, InvoiceManagementDbContext>, IFlatTypeRepository
    {
        public EfFlatTypeDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
