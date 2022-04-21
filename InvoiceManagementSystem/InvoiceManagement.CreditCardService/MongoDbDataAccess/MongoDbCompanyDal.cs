using InvoiceManagement.CreditCardService.MongoDbDataAccess.Base;
using InvoiceManagement.CreditCardService.Entities;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;
using Microsoft.Extensions.Configuration;

namespace InvoiceManagement.CreditCardService.MongoDbDataAccess
{
    public class MongoDbCompanyDal : MongoDbBaseRepository<Company>, ICompanyRepository
    {
        public MongoDbCompanyDal(IConfiguration Configuration) : base(Configuration)
        {
        }
    }
}
