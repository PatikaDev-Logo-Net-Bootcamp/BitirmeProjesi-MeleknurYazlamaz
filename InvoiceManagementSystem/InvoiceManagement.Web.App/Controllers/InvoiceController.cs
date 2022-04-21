using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Abstracts;
using InvoiceManagement.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InvoiceManagement.Web.App.Models.Invoice;
using InvoiceManagement.Web.App.Models.Payment;

namespace InvoiceManagement.Web.App.Controllers
{
    
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceTypeService _invoiceTypeService;
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IInvoiceTypeService invoiceTypeService, IHouseService houseService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _invoiceTypeService = invoiceTypeService;
            _houseService = houseService;
            _mapper = mapper;
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Index()
        {
            var result = _invoiceService.GetAllDetails();
            IEnumerable<GetInvoicesViewModel> model = _mapper.Map<IEnumerable<GetInvoicesViewModel>>(result.Data);
            if (result.Success)
            {
                return View(model);
            }
            return View();
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Create()
        {
            SelectItemInitialize();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Create(CreateInvoiceViewModel model)
        {
            var invoice = _mapper.Map<Invoice>(model);
            var result = _invoiceService.Create(invoice);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return View();
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Edit(int id)
        {
            var data = _invoiceService.GetById(id);
            var returnObj = _mapper.Map<UpdateInvoiceViewModel>(data.Data);
            SelectItemInitialize();
            return View(returnObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Edit(int id, UpdateInvoiceViewModel model)
        {
            var invoice = _mapper.Map<Invoice>(model);
            var result = _invoiceService.Update(id, invoice);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return View();
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Delete(int id)
        {
            var result = _invoiceService.Delete(id);
            SuccessAlert(result.Message);
            return RedirectToAction("Index");
        }

        private void SelectItemInitialize()
        {
            IEnumerable<SelectListItem> selectHouses = _houseService.GetAllHouseDetail().Data.Select(x =>
            {
                return new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.ApartmentName} no: {x.DoorNumber}"
                };
            });
            IEnumerable<SelectListItem> selectInvoiceTypes = _invoiceTypeService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            ViewData.Add("Houses", selectHouses);
            ViewData.Add("InvoiceTypes", selectInvoiceTypes);
        }

        [Authorize(Roles = OperationClaims.AdminOrUser)]
        public IActionResult Pay(int id)
        {
            var invoice = _invoiceService.GetById(id).Data;
            CreatePayOrderViewModel viewModel = new CreatePayOrderViewModel()
            {
                InvoiceId = invoice.Id,
                Amount = invoice.Amount
            };
            return RedirectToAction("Index", "Payment", viewModel);
        }
    }
}
