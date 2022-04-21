using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Dtos
{
    public class RegisterDto : IDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
