
using InvoiceManagement.Core.Entities.Abstracts;
using System;

namespace InvoiceManagement.Entities.Concretes
{
    public class InvoicePayment : IEntity
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public decimal PayingAmount { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
    }
}
