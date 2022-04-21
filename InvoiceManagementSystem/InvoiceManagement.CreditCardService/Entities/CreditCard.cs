namespace InvoiceManagement.CreditCardService.Entities
{
    public class CreditCard
    {
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }

    }
}
