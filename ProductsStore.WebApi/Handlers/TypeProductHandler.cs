using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsStore.Data.ContextDB;
using ProductsStore.Data.Models;
using ProductsStore.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.WebApi.Handlers
{
    public class TypeProductHandler : BaseRepository<TypeProduct>
    {
        public TypeProductHandler(ProductsContext _dbProduts, IMapper mapper) : base(_dbProduts, mapper)
        { }
        public async Task<List<SelectListItem>> GetAllTypeProducts()
        {
            var listTypeProduct = await GetAllEntities();
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
