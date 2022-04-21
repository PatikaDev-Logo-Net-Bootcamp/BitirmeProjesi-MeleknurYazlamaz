using InvoiceManagement.Core.DataAccess.EntityFramework;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfApartmentDal : EfEntityRepositoryBase<Apartment, InvoiceManagementDbContext>, IApartmentRepository
    {
        public EfApartmentDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
