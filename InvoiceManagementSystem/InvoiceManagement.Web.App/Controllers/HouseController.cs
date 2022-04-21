using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Abstracts;
using InvoiceManagement.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using InvoiceManagement.Web.App.Models.House;

namespace InvoiceManagement.Web.App.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;
        private readonly IApartmentService _apartmentService;
        private readonly IFlatTypeService _flatTypeService;
        public HouseController(IHouseService houseService,IApartmentService apartmentService,IFlatTypeService flatTypeService,IMapper mapper)
        {
            _houseService = houseService;
            _apartmentService = apartmentService;
            _flatTypeService = flatTypeService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var result = _houseService.GetAllHouseDetail();
            var rtnObj = _mapper.Map<IEnumerable<GetHousesDetailViewModel>>(result.Data);
            if(result.Success)
                return View(rtnObj);
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
        public IActionResult Create(CreateHouseViewModel model)
        {
            var house = _mapper.Map<House>(model);
            var result = _houseService.Create(house);
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
            var data = _houseService.GetById(id);
            var returnObj = _mapper.Map<UpdateHouseViewModel>(data.Data);
            SelectItemInitialize();
            return View(returnObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = OperationClaims.Admin)]
        public IActionResult Edit(int id,UpdateHouseViewModel model)
        {
            var house = _mapper.Map<House>(model);
            var result = _houseService.Update(id, house);
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
            var result = _houseService.Delete(id);
            SuccessAlert(result.Message);
            return RedirectToAction("Index");
        }


        private void SelectItemInitialize()
        {
            IEnumerable<SelectListItem> selectApartments = _apartmentService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            IEnumerable<SelectListItem> selectFlatTypes = _flatTypeService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.RoomCount} + {x.LivingRoomCount}"
            });
            ViewData.Add("Apartments", selectApartments);
            ViewData.Add("FlatTypes", selectFlatTypes);
        }

    }
}
