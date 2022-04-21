using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Entities.Dtos;
using InvoiceManagement.Web.App.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace InvoiceManagement.Web.App.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;


        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            var loginUser = _mapper.Map<LoginDto>(model);
            var result = _authService.LoginUser(loginUser);
            if (result.Success)
            {
                HttpContext.Session.SetString("Token", result.Data.AccessToken);
                HttpContext.Session.SetString("UserMail",model.Email);
                SuccessAlert(result.Message);
                
                return RedirectToAction("Index","Home");
            }
            DangerAlert(result.Message);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            var registerUser = _mapper.Map<RegisterDto>(model);
            var result = _authService.RegisterUser(registerUser);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return Redirect(Request.Headers["Referer"].ToString());
            }
            DangerAlert(result.Message);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("UserMail");
            InfoAlert("Çıkış Başarılı...");

            return RedirectToAction("Index","Home");
        }
    }
}
