using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using ProductsStore.BusinessLayer.BusinessLogic;
using ProductsStore.Data.ContextDB;
using ProductsStore.Presentation.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly TypeProductBusinessLogic _TypeProductHandler;
        private readonly ProductBusinessLogic _ProductHandler;
        private readonly IMapper _Mapper;
        private readonly IToastNotification _ToastNotification;
        public HomeController(ProductsContext _dbProduts, IMapper mapper, IToastNotification toastNotification)
        {
            _TypeProductHandler = new TypeProductBusinessLogic(_dbProduts, mapper);
            _ProductHandler = new ProductBusinessLogic(_dbProduts, mapper);
            _ToastNotification = toastNotification;
            _Mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var productsList = await _ProductHandler.GetAllProductsWithProxyAsync();
            return View(productsList);
        }
        public async Task<PartialViewResult> RenderProductsCardWithFilter(string description, Guid? id)
        {
            var response = new List<ProductsHomeViewModel>();
            if (Guid.Empty != id && id != null)
            {
                var dataProd = await _ProductHandler.GetProductByIdAsync((Guid)id);
                var dataMapped = _Mapper.Map(dataProd, new ProductsHomeViewModel());
                if (Guid.Empty != dataMapped.Id && dataMapped.Id != null)
                {
                    response.Add(dataMapped);
                }
            }
            else if (!string.IsNullOrEmpty(description))
            {
                response = await _ProductHandler.GetAllProductsByDescriptionWithProxyAsync(description);
            }
            else
            {
                response = await _ProductHandler.GetAllProductsWithProxyAsync();
            }
            return PartialView(response);
        }
        public async Task<ActionResult> CreateProduct()
        {
            List<SelectListItem> lstActiveProduct = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Choose", Value = "" },
                new SelectListItem{ Text = "Yes", Value = "True" },
                new SelectListItem{ Text = "No", Value = "False" },
            };
            var lsTypeProduct = await _TypeProductHandler.GetAllTypeProductsAsync();
            ViewBag.OptionsTypeProduct = lsTypeProduct;
            ViewBag.OptionsValue = lstActiveProduct;

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> InsertProduct(CreateProductEditViewModel data)
        {
            var response = await _ProductHandler.CreateDbProductAsync(data);
            if (response.IsSuccess)
            {
                _ToastNotification.AddSuccessToastMessage("Product created");
            }
            else
            {
                _ToastNotification.AddErrorToastMessage("Internal server error");
            }
            return Json(new { response.IsSuccess, redirectToUrl = Url.Action("", "Home", new { area = "Admin" }) });
        }
        public async Task<ActionResult> UpdateProduct(Guid id)
        {
            var response = await _ProductHandler.GetProductByIdAsync(id);
            List<SelectListItem> lstActiveProduct = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Choose", Value = "" },
                new SelectListItem{ Text = "Yes", Value = "True" },
                new SelectListItem{ Text = "No", Value = "False" },
            };
            var lsTypeProduct = await _TypeProductHandler.GetAllTypeProductsAsync();
            ViewBag.OptionsTypeProduct = lsTypeProduct;
            ViewBag.OptionsValue = lstActiveProduct;
            return View(response);
        }
        public async Task<JsonResult> UpdateProductInformation(EditProductEditViewModel data)
        {
            var response = await _ProductHandler.UpdateProductInformationAsync(data);
            if (response.IsSuccess)
            {
                _ToastNotification.AddSuccessToastMessage("Product updated");
            }
            else
            {
                _ToastNotification.AddErrorToastMessage("Internal server error");
            }
            return Json(new { response.IsSuccess, redirectToUrl = Url.Action("", "Home", new { area = "Admin" }) });
        }
    }
}
