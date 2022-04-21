using System;

namespace InvoiceManagement.CreditCardService.Entities
{
    public class Payment : EntityBase
    {
        public CreditCard CreditCard { get; set; }
        public string CompanyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayTime { get; set; } = DateTime.Now;
        

    }
}
