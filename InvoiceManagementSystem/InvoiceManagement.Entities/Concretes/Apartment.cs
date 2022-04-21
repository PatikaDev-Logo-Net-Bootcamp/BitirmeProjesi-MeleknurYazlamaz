using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Concretes
{
    public class Apartment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalFloors { get; set; }
        public string Block { get; set; }
    }
}
