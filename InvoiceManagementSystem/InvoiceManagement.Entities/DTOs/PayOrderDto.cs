using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Dtos
{
    public class PayOrderDto :IDto
    {
        public int InvoiceId { get; set; }
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }
        public decimal Amount { get; set; }
    }
}
