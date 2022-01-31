using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly LoginHandler LoginHandlerRepo;
        public LoginController(ProductsContext _dbProduts)
        {
            LoginHandlerRepo = new LoginHandler(_dbProduts);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> SignIn(UserViewModel dataLogin)
        {
            var user = await LoginHandlerRepo.SignIn(dataLogin);
            if (user.IdUser != null && user.IdUser != Guid.Empty)
            {
                HttpContext.Session.SetObject("UserSession", user);
                return Json(new { IsSuccess = true });
            }
            return Json(new { IsSuccess = false, Error = "User not found" });
        }
    }
}
