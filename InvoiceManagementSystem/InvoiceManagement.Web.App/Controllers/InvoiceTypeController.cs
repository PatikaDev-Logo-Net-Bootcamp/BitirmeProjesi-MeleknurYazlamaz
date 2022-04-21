using System.Collections.Generic;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Abstracts;
using InvoiceManagement.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InvoiceManagement.Web.App.Models.InvoiceType;

namespace InvoiceManagement.Web.App.Controllers
{
    public class InvoiceTypeController : BaseController
    {
        private readonly IInvoiceTypeService _invoiceTypeService;
        private readonly IMapper _mapper;
        public InvoiceTypeController(IInvoiceTypeService invoiceTypeService, IMapper mapper)
        {
            _invoiceTypeService = invoiceTypeService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var result = _invoiceTypeService.GetAll();
            if (result.Success)
            {
                IEnumerable<GetInvoiceTypesViewModel> obj = _mapper.Map<IEnumerable<GetInvoiceTypesViewModel>>(result.Data);
                return View(obj);
            }
            return View();

        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Create(CreateInvoiceTypeViewModel createFlatType)
        {
            InvoiceType model = _mapper.Map<InvoiceType>(createFlatType);
            var result = _invoiceTypeService.Create(model);
            SuccessAlert(result.Message);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Delete(int id)
        {
            var result = _invoiceTypeService.Delete(id);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Edit(int id)
        {
            var result = _invoiceTypeService.GetById(id);
            if (result.Success)
            {
                UpdateInvoiceTypeViewModel model = _mapper.Map<UpdateInvoiceTypeViewModel>(result.Data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Edit(int id, UpdateInvoiceTypeViewModel model)
        {
            InvoiceType mapObj = _mapper.Map<InvoiceType>(model);
            var result = _invoiceTypeService.Update(id, mapObj);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return RedirectToAction("Index");
        }
    }
}
