using InvoiceManagement.CreditCardService.Entities;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Base;

namespace InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts
{
    public interface IPaymentRepository : IMongoDbBaseRepository<Payment>
    {
    }
}
