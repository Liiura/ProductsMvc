﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsStore.ContextDB;
using ProductsStore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProductsStore.Handlers
{
    public class TypeProductHandler : BaseHandler<TypeProduct>
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
