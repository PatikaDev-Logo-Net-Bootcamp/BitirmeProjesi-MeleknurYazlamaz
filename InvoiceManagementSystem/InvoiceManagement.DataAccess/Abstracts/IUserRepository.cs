using InvoiceManagement.Core.DataAccess;
using InvoiceManagement.Core.Entities.Concretes;

namespace InvoiceManagement.DataAccess.Abstracts
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}
