using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Dtos
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public long CitizenId { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public bool IsActive { get; set; } 
    }
}
