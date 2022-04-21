using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Concretes
{
    public class FlatType : IEntity
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public int LivingRoomCount { get; set; }

    }
}
