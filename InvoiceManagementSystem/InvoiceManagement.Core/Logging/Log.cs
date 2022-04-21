using InvoiceManagement.Core.Entities.Abstracts;
using System;

namespace InvoiceManagement.Core.Logging
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
    }
}
