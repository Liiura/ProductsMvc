using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsStore.Data.ContextDB;
using ProductsStore.WebApi.Handlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.BusinessLayer.BusinessLogic
{
    public class TypeProductBusinessLogic
    {
        private readonly TypeProductHandler _TypeProductHandler;
        public TypeProductBusinessLogic(ProductsContext dbContext, IMapper mapper)
        {
            _TypeProductHandler = new TypeProductHandler(dbContext, mapper);
        }
        public async Task<List<SelectListItem>> GetAllTypeProductsAsync()
        {
            return await _TypeProductHandler.GetAllTypeProducts();
        }
    }
}
