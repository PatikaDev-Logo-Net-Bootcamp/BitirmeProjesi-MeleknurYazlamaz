namespace InvoiceManagement.Web.App.Models.Resident
{
    public class UpdateResidentViewModel
    {
        public int UserId { get; set; }
        public int HouseId { get; set; }
        public bool IsHirer { get; set; }
        public bool IsOwner { get; set; }
        public string CarPlate { get; set; }
    }
}
