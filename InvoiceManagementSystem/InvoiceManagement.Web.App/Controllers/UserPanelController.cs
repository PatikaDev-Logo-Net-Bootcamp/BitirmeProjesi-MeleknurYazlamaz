using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Abstracts;
using InvoiceManagement.Web.App.Models.UserPanel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace InvoiceManagement.Web.App.Controllers
{
    [Authorize(Roles = OperationClaims.AdminOrUser)]
    public class UserPanelController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public UserPanelController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Invoices()
        {
            var value = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value != null)
            {
                int userId = Int32.Parse(value);
                var result = _invoiceService.GetAllUserInvoiceDetail(userId);
                IEnumerable<GetUserInvoicesViewModel> model =
                    _mapper.Map<IEnumerable<GetUserInvoicesViewModel>>(result.Data);
                return View(model);
            }
            return RedirectToAction("Login", "Auth");
        }

    }
}
