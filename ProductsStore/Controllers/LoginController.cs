using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ProductsStore.BusinessLayer.BusinessLogic;
using ProductsStore.Data.ContextDB;
using ProductsStore.Extensions;
using ProductsStore.Presentation.SharedViewModels;
using System;
using System.Threading.Tasks;

namespace ProductsStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginBusinessLogic _LoginHandlerRepo;
        private readonly IToastNotification _ToastNotification;
        public LoginController(ProductsContext dbContext, IToastNotification toastNotification)
        {
            _LoginHandlerRepo = new LoginBusinessLogic(dbContext);
            _ToastNotification = toastNotification;
        }
        public ActionResult Index()
        {
            var currentSessionObject = HttpContext.Session.GetObject<SessionModel>("UserSession");
            if (currentSessionObject != null)
            {
                if (currentSessionObject.RoleType == "Admin")
                {
                    return RedirectToAction("", "Home", new { area = "Admin" });
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> SignIn(UserViewModel dataLogin)
        {
            var user = await _LoginHandlerRepo.SignInAsync(dataLogin);
            if (user.IdUser != null && user.IdUser != Guid.Empty)
            {
                HttpContext.Session.SetObject("UserSession", user);
                return Json(new { IsSuccess = true, redirectToUrl = Url.Action("", "Home", new { area = "Admin" }) });
            }
            _ToastNotification.AddErrorToastMessage(message: "Your request couldn't be processed");
            return Json(new { IsSuccess = false, Error = "User not found" });
        }
    }
}
