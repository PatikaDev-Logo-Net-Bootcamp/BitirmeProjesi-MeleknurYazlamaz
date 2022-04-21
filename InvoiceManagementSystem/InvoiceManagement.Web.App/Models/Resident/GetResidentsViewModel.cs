namespace InvoiceManagement.Web.App.Models.Resident
{
    public class GetResidentsViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string House { get; set; }
        public bool IsHirer { get; set; }
        public bool IsOwner { get; set; }
        public string CarPlate { get; set; }
    }
}
