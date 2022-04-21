using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Entities.Dtos;
using System.Threading.Tasks;

namespace InvoiceManagement.Business.Services.Abstracts
{
    public interface IInvoicePaymentService
    {
        Task<IResult> PayInvoice(int userId, PayOrderDto payOrder);
    }
}
