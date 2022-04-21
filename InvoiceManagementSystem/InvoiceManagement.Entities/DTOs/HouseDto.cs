using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Dtos
{
    public class HouseDto : IDto
    {
        public int Id { get; set; }
        public string ApartmentName { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string FlatType { get; set; }
    }
}
