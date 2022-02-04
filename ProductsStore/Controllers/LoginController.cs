using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ProductsStore.ContextDB;
using ProductsStore.Extensions;
using ProductsStore.Handlers;
using ProductsStore.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProductsStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginHandler _LoginHandlerRepo;
        private readonly IToastNotification _ToastNotification;
        public LoginController(ProductsContext _dbProduts, IToastNotification toastNotification)
        {
            _LoginHandlerRepo = new LoginHandler(_dbProduts);
            _ToastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> SignIn(UserViewModel dataLogin)
        {
            var user = await _LoginHandlerRepo.SignIn(dataLogin);
            if (user.IdUser != null && user.IdUser != Guid.Empty)
            {
                HttpContext.Session.SetObject("UserSession", user);
                return Json(new { IsSuccess = true, redirectToUrl = Url.Action("", "", new { area = "Admin" }) });
            }
            _ToastNotification.AddErrorToastMessage(message: "Your request couldn't be processed");
            return Json(new { IsSuccess = false, Error = "User not found" });
        }
    }
}
