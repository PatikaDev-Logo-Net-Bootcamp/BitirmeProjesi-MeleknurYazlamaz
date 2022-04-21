using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Concretes
{
    public class InvoiceType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
