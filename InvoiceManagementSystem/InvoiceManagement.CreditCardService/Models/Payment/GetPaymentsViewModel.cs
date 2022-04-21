using System;

namespace InvoiceManagement.CreditCardService.Models.Payment
{
    public class GetPaymentsViewModel
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public DateTime PayTime { get; set; }
        public CreateCreditCardVM CreditCard { get; set; }
        public struct CreateCreditCardVM
        {
            public string CardHolderName { get; set; }
            public long CardNumber { get; set; }
            public int ExpirationMouth { get; set; }
            public int ExpirationYear { get; set; }
            public int CVCCode { get; set; }
        }
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
