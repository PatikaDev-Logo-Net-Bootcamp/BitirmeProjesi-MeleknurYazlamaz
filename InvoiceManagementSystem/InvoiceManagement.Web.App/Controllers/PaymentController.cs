using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Abstracts;
using InvoiceManagement.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvoiceManagement.Web.App.Models.Payment;

namespace InvoiceManagement.Web.App.Controllers
{
    [Authorize(Roles = OperationClaims.AdminOrUser)]
    public class PaymentController : BaseController
    {
        private readonly IInvoicePaymentService _InvoicePaymentService;
        private readonly IMapper _mapper;

        
        public PaymentController(IInvoicePaymentService InvoicePaymentService, IMapper mapper)
        {
            _InvoicePaymentService = InvoicePaymentService;
            _mapper = mapper;
        }

        public IActionResult Index(CreatePayOrderViewModel payOrder)
        {
            return View(payOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayOrder(CreatePayOrderViewModel payOrder)
        {
            var postModel = _mapper.Map<PayOrderDto>(payOrder);
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _InvoicePaymentService.PayInvoice(Int32.Parse(userId), postModel);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index", "Invoice");
            }
            DangerAlert(result.Message);
            return RedirectToAction("Index",routeValues:payOrder);
        }
    }
}
