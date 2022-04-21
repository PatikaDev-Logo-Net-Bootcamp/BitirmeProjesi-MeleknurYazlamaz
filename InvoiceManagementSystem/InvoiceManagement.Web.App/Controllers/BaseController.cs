using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.Web.App.Controllers
{
    public class BaseController : Controller
    {
        public void SuccessAlert(string message)
        {
            TempData["alertType"] = "success";
            TempData["alertMessage"] = message;
        }

        public void DangerAlert(string message)
        {
            TempData["alertType"] = "danger";
            TempData["alertMessage"] = message;
        }

        public void InfoAlert(string message)
        {
            TempData["alertType"] = "info";
            TempData["alertMessage"] = message;
        }

    }
}
