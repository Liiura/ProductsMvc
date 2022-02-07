using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ProductsStore.Areas.Admin.Data;
using ProductsStore.ContextDB;
using ProductsStore.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ProductsContext _DbProducts;
        private readonly IMapper _Mapper;
        private readonly TypeProductHandler _TypeProductHandler;
        private readonly ProductsHandler _ProductHandler;
        private readonly IToastNotification _ToastNotification;
        public HomeController(ProductsContext _dbProduts, IMapper mapper, IToastNotification toastNotification)
        {
            _DbProducts = _dbProduts;
            _Mapper = mapper;
            _TypeProductHandler = new TypeProductHandler(_DbProducts, _Mapper);
            _ProductHandler = new ProductsHandler(_DbProducts, _Mapper);
            _ToastNotification = toastNotification;
        }
        public async Task<ActionResult> Index()
        {
            var productsList = await _ProductHandler.GetAllProductsWithProxy();
            return View(productsList);
        }
        public async Task<ActionResult> CreateProduct()
        {
            List<SelectListItem> lstActiveProduct = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Choose", Value = "" },
                new SelectListItem{ Text = "Yes", Value = "True" },
                new SelectListItem{ Text = "No", Value = "False" },
            };
            var lsTypeProduct = await _TypeProductHandler.GetAllTypeProducts();
            ViewBag.OptionsTypeProduct = lsTypeProduct;
            ViewBag.OptionsValue = lstActiveProduct;

            return View();
        }
        [HttpPost]
        public async Task InsertProduct(CreateProductEditViewModel data)
        {
            var response = await _ProductHandler.CreateDbProduct(data);
            if (response.IsSuccess)
            {
                _ToastNotification.AddSuccessToastMessage("Product created");
            }
            else
            {
                _ToastNotification.AddErrorToastMessage("Internal server error");
            }
        }
        public async Task<ActionResult> UpdateProduct(Guid id)
        {
            var response = await _ProductHandler.GetProductById(id);
            List<SelectListItem> lstActiveProduct = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Choose", Value = "" },
                new SelectListItem{ Text = "Yes", Value = "True" },
                new SelectListItem{ Text = "No", Value = "False" },
            };
            var lsTypeProduct = await _TypeProductHandler.GetAllTypeProducts();
            ViewBag.OptionsTypeProduct = lsTypeProduct;
            ViewBag.OptionsValue = lstActiveProduct;
            return View(response);
        }
    }
}
