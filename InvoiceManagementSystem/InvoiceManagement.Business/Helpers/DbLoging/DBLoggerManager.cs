using InvoiceManagement.Core.Logging;
using InvoiceManagement.DataAccess.Abstracts;

namespace InvoiceManagement.Business.Helpers.DbLoging
{
    public class DBLoggerManager : ILoggerService
    {
        private readonly ILogRepository _logRepository;

        public DBLoggerManager(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public void Log(string message)
        {
            _logRepository.Add(new Log{Message = message});
            _logRepository.SaveChanges();
        }
    }
}
