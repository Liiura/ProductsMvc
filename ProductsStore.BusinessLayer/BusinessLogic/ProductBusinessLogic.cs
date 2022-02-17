using AutoMapper;
using ProductsStore.Data.ContextDB;
using ProductsStore.Presentation.AdminViewModels;
using ProductsStore.Presentation.SharedViewModels;
using ProductsStore.WebApi.Handlers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.BusinessLayer.BusinessLogic
{
    public class ProductBusinessLogic
    {
        private readonly ProductsHandler _ProductsHandler;
        public ProductBusinessLogic(ProductsContext dbContext, IMapper mapper)
        {
            _ProductsHandler = new ProductsHandler(dbContext, mapper);
        }
        public async Task<ResponsePayload> CreateDbProductAsync(CreateProductEditViewModel data)
        {
            return await _ProductsHandler.CreateDbProduct(data);
        }
        public async Task<List<ProductsHomeViewModel>> GetAllProductsWithProxyAsync()
        {
            return await _ProductsHandler.GetAllProductsWithProxy();
        }
        public async Task<List<ProductsHomeViewModel>> GetAllProductsByDescriptionWithProxyAsync(string description)
        {
            return await _ProductsHandler.GetAllProductsByDescriptionWithProxy(description);
        }
        public async Task<EditProductEditViewModel> GetProductByIdAsync(Guid id)
        {
            return await _ProductsHandler.GetProductById(id);
        }
        public async Task<ResponsePayload> UpdateProductInformationAsync(EditProductEditViewModel data)
        {
            return await _ProductsHandler.UpdateProductInformation(data);
        }
    }
}
