using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsStore.ContextDB;
using ProductsStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProductsStore.Handlers
{
    public class TypeProductHandler
    {
        private readonly ProductsContext _DbProducts;
        private readonly IMapper _Mapper;
        private BaseHandler<TypeProduct> _TypeProductBaseHandler;
        public TypeProductHandler(ProductsContext _dbProduts, IMapper mapper)
        {
            _DbProducts = _dbProduts;
            _Mapper = mapper;
            _TypeProductBaseHandler = new BaseHandler<TypeProduct>(_DbProducts, _Mapper);
        }
        public async Task<List<SelectListItem>> GetAllTypeProducts()
        {
            var listTypeProduct = await _TypeProductBaseHandler.GetAllEntities();
            var selectViewTypeProductList = new List<SelectListItem>();
            selectViewTypeProductList.Add(new SelectListItem { Text = "Choose", Value = "" });
            foreach (var typeProduct in listTypeProduct)
            {
                selectViewTypeProductList.Add(new SelectListItem { Text = typeProduct.TypeName, Value = Convert.ToString(typeProduct.Id) });
            }
            return selectViewTypeProductList;
        }
    }
}
