using InvoiceManagement.Core.Entities.Abstracts;
using System;

namespace InvoiceManagement.Core.Entities.Concretes
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public long CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string OperationClaim { get; set; } = OperationClaims.User;
        public string RefreshToken { get; set; }
        public DateTime? RefresTokenExpireDate { get; set; }
        public bool IsActive { get; set; } = true;
       
    }
}
