
using InvoiceManagement.Core.Entities.Abstracts;
using System;

namespace InvoiceManagement.Entities.Concretes
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public int HouseId { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; } = true;
        public DateTime InvoiceDate { get; set; }

    }
}
