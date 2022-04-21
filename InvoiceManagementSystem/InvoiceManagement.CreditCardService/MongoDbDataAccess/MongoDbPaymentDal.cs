using InvoiceManagement.CreditCardService.MongoDbDataAccess.Base;
using InvoiceManagement.CreditCardService.Entities;
using Microsoft.Extensions.Configuration;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;

namespace InvoiceManagement.CreditCardService.MongoDbDataAccess
{
    public class MongoDbPaymentDal : MongoDbBaseRepository<Payment> , IPaymentRepository
    {
        public MongoDbPaymentDal(IConfiguration Configuration) : base(Configuration)
        {
        }
    }
}
