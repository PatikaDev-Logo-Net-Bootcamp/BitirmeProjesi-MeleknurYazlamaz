using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InvoiceManagement.Web.App.Models.House
{
    public class CreateHouseViewModel
    {
        public int ApartmentId { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public int FlatTypeId { get; set; }
        public IEnumerable<SelectListItem> Apartments { get; set; }
        public IEnumerable<SelectListItem> FlatTypes { get; set; }

    }
}
