using AutoMapper;
using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using InvoiceManagement.Web.App.Models.Apartment;
using InvoiceManagement.Web.App.Models.Auth;
using InvoiceManagement.Web.App.Models.FlatType;
using InvoiceManagement.Web.App.Models.House;
using InvoiceManagement.Web.App.Models.Invoice;
using InvoiceManagement.Web.App.Models.InvoiceType;
using InvoiceManagement.Web.App.Models.Payment;
using InvoiceManagement.Web.App.Models.Resident;
using InvoiceManagement.Web.App.Models.User;
using InvoiceManagement.Web.App.Models.UserPanel;

namespace InvoiceManagement.Web.App.Tools.Helpers
{
    public class UserAutoMapperHelper : Profile
    {
        public UserAutoMapperHelper()
        {   
            CreateMap<Apartment,GetApartmentsViewModel>();
            CreateMap<Apartment,GetApartmentViewModel>();
            CreateMap<Apartment,UpdateApartmentViewModel>();
            CreateMap<CreateApartmentViewModel,Apartment>();
            CreateMap<UpdateApartmentViewModel,Apartment>();

            CreateMap<FlatType,GetFlatTypesViewModel>();
            CreateMap<FlatType,UpdateFlatTypeViewModel>();
            CreateMap<CreateFlatTypeViewModel,FlatType>();
            CreateMap<UpdateFlatTypeViewModel,FlatType>();

            CreateMap<HouseDto, GetHousesDetailViewModel>();
            CreateMap<CreateHouseViewModel, House>();
            CreateMap<House, UpdateHouseViewModel>();
            CreateMap<UpdateHouseViewModel, House>();

            CreateMap<InvoiceType, GetInvoiceTypesViewModel>();
            CreateMap<InvoiceType, UpdateInvoiceTypeViewModel>();
            CreateMap<CreateInvoiceTypeViewModel, InvoiceType>();
            CreateMap<UpdateInvoiceTypeViewModel, InvoiceType>();

            CreateMap<ResidentDto, GetResidentsViewModel>();
            CreateMap<Resident, UpdateResidentViewModel>();
            CreateMap<CreateResidentViewModel, Resident>();
            CreateMap<UpdateResidentViewModel, Resident>();

            CreateMap<LoginViewModel, LoginDto>();
            CreateMap<RegisterViewModel, RegisterDto>();

            CreateMap<Invoice, GetInvoiceViewModel>();
            CreateMap<InvoiceDto, GetInvoicesViewModel>();
            CreateMap<Invoice, UpdateInvoiceViewModel>();
            CreateMap<CreateInvoiceViewModel, Invoice>();
            CreateMap<UpdateInvoiceViewModel, Invoice>();

            CreateMap<CreatePayOrderViewModel, PayOrderDto>();

            CreateMap<UserDto, GetUserViewModel>();
            CreateMap<UserDto, UpdateUserViewModel>();
            CreateMap<UpdateUserViewModel, User>();

            CreateMap<InvoiceDto, GetUserInvoicesViewModel>();
        }
    }
}
