using AutoMapper;
using Business.Services.OutsideService.PaymentService;
using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;

namespace InvoiceManagement.Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<PayOrderDto, PaymentOrder>();
            CreateMap<User, UserDto>();
        }
    }
}
