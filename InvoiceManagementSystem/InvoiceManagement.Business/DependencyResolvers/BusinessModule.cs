using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Business.Services.Concretes;
using InvoiceManagement.Business.Services.OtherServices.PaymentService;
using InvoiceManagement.DataAccess.Concretes.EntityFramework;

using InvoiceManagement.DataAccess.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using InvoiceManagement.Core.Utilities.IoC;

namespace InvoiceManagement.Business.DependencyResolvers
{
    public class BusinessModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, EfUserDal>();
            serviceCollection.AddScoped<IApartmentRepository,EfApartmentDal>();
            serviceCollection.AddScoped<IFlatTypeRepository,EfFlatTypeDal>();
            serviceCollection.AddScoped<IHouseRepository,EfHouseDal>();
            serviceCollection.AddScoped<IInvoiceRepository,EfInvoiceDal>();
            serviceCollection.AddScoped<IInvoiceTypeRespository,EfInvoiceTypeDal>();
            serviceCollection.AddScoped<IResidentRepository,EfResidentDal>();
            serviceCollection.AddScoped<ILogRepository, EfLogDal>();
            serviceCollection.AddScoped<IInvoicePaymentRepository, EfInvoicePaymentDal>();
            
            serviceCollection.AddScoped<IUserService, UserManager>();
            serviceCollection.AddScoped<IAuthService,AuthManager>();
            serviceCollection.AddScoped<IApartmentService,ApartmentManager>();
            serviceCollection.AddScoped<IFlatTypeService,FlatTypeManager>();
            serviceCollection.AddScoped<IHouseService, HouseManager>();
            serviceCollection.AddScoped<IInvoiceTypeService, InvoiceTypeManager>();
            serviceCollection.AddScoped<IResidentService, ResidentManager>();
            serviceCollection.AddScoped<IInvoiceService, InvoiceManager>();
            serviceCollection.AddScoped<IInvoicePaymentService,InvoicePaymentManager>();

            serviceCollection.AddScoped<IPaymentService,PaymentManager>();


        }
    }
}
