using System.ComponentModel;

namespace InvoiceManagement.Web.App.Models.Apartment
{
    public class CreateApartmentViewModel
    {
        public string Name { get; set; }
        
        [DisplayName("Total Floors")]
        public int TotalFloors { get; set; }
    }
}
