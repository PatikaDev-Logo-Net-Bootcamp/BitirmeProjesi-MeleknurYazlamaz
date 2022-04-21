using System;

namespace InvoiceManagement.Web.App.Models.Invoice
{
    public class UpdateInvoiceViewModel
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public int HouseId { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
