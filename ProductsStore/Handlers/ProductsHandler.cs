using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsStore.Areas.Admin.Data;
using ProductsStore.ContextDB;
using ProductsStore.Models;
using ProductsStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Handlers
{
    public class ProductsHandler
    {
        private readonly ProductsContext _DbProducts;
        private readonly IMapper _Mapper;
        private BaseHandler<Product> _ProductBaseHandler;
        public ProductsHandler(ProductsContext _dbProduts, IMapper mapper)
        {
            _DbProducts = _dbProduts;
            _Mapper = mapper;
            _ProductBaseHandler = new BaseHandler<Product>(_DbProducts, _Mapper);
        }
        public async Task<ResponsePayload> CreateDbProduct(CreateProductEditViewModel data)
        {
            var productToInsert = new Product();
            var payload = await _ProductBaseHandler.InsertEntity(data, productToInsert);
            return payload;

        }
        public async Task<List<ProductsHomeViewModel>> GetAllProductsWithProxy()
        {
            try
            {
                using (var context = _DbProducts)
                {
                    var lsProductViewModel = new List<ProductsHomeViewModel>();
                    var payload = await context.Product.ToListAsync();
                    foreach (var productItem in payload)
                    {
                        lsProductViewModel.Add(new ProductsHomeViewModel { Description = productItem.Description, TypeProduct = productItem.Type.TypeName, Id = productItem.ID });
                    }
                    return lsProductViewModel;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<EditProductEditViewModel> GetProductById(Guid id)
        {
            var payload = await _ProductBaseHandler.GetOneEntity(id);
            var dataMapped = _Mapper.Map(payload, new EditProductEditViewModel());
            return dataMapped;

        }
    }
}
