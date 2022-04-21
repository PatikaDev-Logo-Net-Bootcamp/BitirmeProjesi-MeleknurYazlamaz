namespace InvoiceManagement.Web.App.Models.User
{
    public class UpdateUserViewModel
    {
        public int Id { get; set; }
        public long CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
