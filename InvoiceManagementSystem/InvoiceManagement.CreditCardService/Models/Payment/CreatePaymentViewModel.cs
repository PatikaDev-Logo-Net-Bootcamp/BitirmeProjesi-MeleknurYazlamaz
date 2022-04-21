namespace InvoiceManagement.CreditCardService.Models.Payment
{
    public class CreatePaymentViewModel
    {
        public string CompanyId { get; set; }
        public double Amount { get; set; }
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }

    }
}
