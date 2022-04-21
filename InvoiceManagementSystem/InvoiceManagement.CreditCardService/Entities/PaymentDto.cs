using System;

namespace InvoiceManagement.CreditCardService.Entities
{
    public class PaymentDto
    {
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }
        public string CompanyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayTime { get; set; }
    }
}
