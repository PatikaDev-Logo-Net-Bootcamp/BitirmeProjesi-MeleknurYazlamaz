using InvoiceManagement.Core.Logging;
using InvoiceManagement.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagement.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILoggerService, DBLogger>();

        }
    }
}
