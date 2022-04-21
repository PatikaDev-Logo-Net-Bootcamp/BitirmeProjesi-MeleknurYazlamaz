using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Abstracts;
using InvoiceManagement.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InvoiceManagement.Web.App.Models.Resident;

namespace InvoiceManagement.Web.App.Controllers
{
    [Authorize(Roles = OperationClaims.Admin)]
    public class ResidentController : BaseController
    {
        private readonly IResidentService _residentService;
        private readonly IUserService _userService;
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public ResidentController(IResidentService residentService, IUserService userService, IHouseService houseService, IMapper mapper)
        {
            _residentService = residentService;
            _userService = userService;
            _houseService = houseService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _residentService.GetAllDetails();
            var returnObj = _mapper.Map<IEnumerable<GetResidentsViewModel>>(result.Data);
            return View(returnObj);
        }

        public IActionResult Create()
        {
            SelectItemInitialize();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateResidentViewModel model)
        {
            var resident = _mapper.Map<Resident>(model);
            var result = _residentService.Create(resident);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return View();
        }

        public IActionResult Edit(int id)
        {
            SelectItemInitialize();
            var result = _residentService.GetById(id);
            if (result.Success)
            {
                var returnObj = _mapper.Map<UpdateResidentViewModel>(result.Data);
                return View(returnObj);
            }
            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateResidentViewModel model)
        {
            var resident = _mapper.Map<Resident>(model);
            var result = _residentService.Update(id, resident);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return View();
        }


        public IActionResult Delete(int id)
        {
            var result = _residentService.Delete(id);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return BadRequest();
        }

        private void SelectItemInitialize()
        {
            IEnumerable<SelectListItem> selectApartments = _houseService.GetAllHouseDetail().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.ApartmentName} no: {x.DoorNumber}"
            });
            IEnumerable<SelectListItem> selectUsers = _userService.GetAllUser().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            });

            ViewData.Add("Houses", selectApartments);
            ViewData.Add("Users", selectUsers);
        }
    }
}
