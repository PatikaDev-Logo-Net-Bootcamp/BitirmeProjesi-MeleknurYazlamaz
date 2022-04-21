using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Concretes
{
    public class Resident : IEntity
    {
        public int UserId { get; set; }
        public int HouseId { get; set; }
        public bool IsHirer { get; set; }
        public bool IsOwner { get; set; }
        public string CarPlate { get; set; }

    }
}
