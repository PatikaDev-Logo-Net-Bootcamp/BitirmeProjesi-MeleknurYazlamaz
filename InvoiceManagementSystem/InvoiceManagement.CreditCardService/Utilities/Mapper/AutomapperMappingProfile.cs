using AutoMapper;
using InvoiceManagement.CreditCardService.Models.Company;
using InvoiceManagement.CreditCardService.Models.Payment;
using InvoiceManagement.CreditCardService.Entities;

namespace InvoiceManagement.CreditCardService.Utilities.Mapper
{
    public class AutomapperMappingProfile : Profile
    {
        public AutomapperMappingProfile()
        {
            CreateMap<CreateCompanyViewModel, Company>();
            CreateMap<Company, GetCompaniesViewModel>();
            
            CreateMap<CreatePaymentViewModel, CreditCard>();
            CreateMap<CreatePaymentViewModel, Payment>();
            
            CreateMap<Payment, GetPaymentsViewModel>();
            CreateMap<CreditCard,GetPaymentsViewModel.CreateCreditCardVM>();

        }
    }
}
