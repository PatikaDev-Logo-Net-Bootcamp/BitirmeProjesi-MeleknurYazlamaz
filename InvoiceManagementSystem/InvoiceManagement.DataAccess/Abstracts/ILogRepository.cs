using InvoiceManagement.Core.DataAccess;
using InvoiceManagement.Core.Logging;

namespace InvoiceManagement.DataAccess.Abstracts
{
    public interface ILogRepository : IEntityRepository<Log>
    {
    }
}
