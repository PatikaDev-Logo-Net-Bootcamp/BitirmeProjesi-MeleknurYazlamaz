using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagement.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
