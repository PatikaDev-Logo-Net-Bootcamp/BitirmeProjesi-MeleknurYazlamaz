using InvoiceManagement.Core.Entities.Abstracts;
using System;

namespace InvoiceManagement.Entities.Dtos
{
    public class InvoiceDto : IDto
    {
        public int Id { get; set; }
        public string InvoiceType { get; set; }
        public string House { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
