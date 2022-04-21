using InvoiceManagement.Core.Entities.Abstracts;

namespace InvoiceManagement.Entities.Dtos
{
    public class LoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
