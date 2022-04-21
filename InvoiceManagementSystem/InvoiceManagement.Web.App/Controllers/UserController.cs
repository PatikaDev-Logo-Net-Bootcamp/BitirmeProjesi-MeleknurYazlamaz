using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Web.App.Models.User;
using Microsoft.AspNetCore.Mvc;


namespace InvoiceManagement.Web.App.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IAuthService authService, IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value = HttpContext.User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value != null)
            {
                int userId = Int32.Parse(value);
                var user = _userService.GetByIdUser(userId);
                GetUserViewModel model = _mapper.Map<GetUserViewModel>(user.Data);
                return View(model);
            }
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult Edit(int id)
        {
            
                var user = _userService.GetByIdUser(id);
                UpdateUserViewModel model = _mapper.Map<UpdateUserViewModel>(user.Data);
                return View(model);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,UpdateUserViewModel model)
        {
            User user = _mapper.Map<User>(model);
            var result = _userService.Update(id,user);
            SuccessAlert(result.Message);
            return RedirectToAction("Index");
        }
    }
}
