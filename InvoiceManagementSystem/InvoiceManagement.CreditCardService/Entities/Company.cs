namespace InvoiceManagement.CreditCardService.Entities
{
    public class Company:EntityBase
    {

        public string Name { get; set; }
        public long TaxNumber { get; set; }
        public string TaxAdministrator { get; set; }

    }
}
