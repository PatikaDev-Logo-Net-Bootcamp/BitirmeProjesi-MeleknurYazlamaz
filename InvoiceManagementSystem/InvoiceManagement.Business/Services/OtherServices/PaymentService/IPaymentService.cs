using Business.Services.OutsideService.PaymentService;
using InvoiceManagement.Core.Utilities.Results;
using System.Threading.Tasks;

namespace InvoiceManagement.Business.Services.OtherServices.PaymentService
{
    public interface IPaymentService
    {
        Task<PaymentResult> PayOrder(PaymentOrder payOrder);
        Task<IDataResult<object>> CompanyAllPayOrder();

    }
}
