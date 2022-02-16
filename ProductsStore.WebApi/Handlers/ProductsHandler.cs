using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsStore.Data.ContextDB;
using ProductsStore.Data.Models;
using ProductsStore.Presentation.AdminViewModels;
using ProductsStore.Presentation.SharedViewModels;
using ProductsStore.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.WebApi.Handlers
{
    public class ProductsHandler : BaseRepository<Product>
    {
        private readonly ProductsContext _DbProducts;
        private readonly IMapper _Mapper;
        public ProductsHandler(ProductsContext _dbProduts, IMapper mapper) : base(_dbProduts, mapper)
        {
            _DbProducts = _dbProduts;
            _Mapper = mapper;
        }
        public async Task<ResponsePayload> CreateDbProduct(CreateProductEditViewModel data)
        {
            var productToInsert = new Product();
            var payload = await InsertEntity(data, productToInsert);
            return payload;

        }
        public async Task<List<ProductsHomeViewModel>> GetAllProductsWithProxy()
        {
            try
            {
                var lsProductViewModel = new List<ProductsHomeViewModel>();
                var payload = await _DbProducts.Product.ToListAsync();
                foreach (var productItem in payload)
                {
                    lsProductViewModel.Add(new ProductsHomeViewModel { Description = productItem.Description, TypeProduct = productItem.Type.TypeName, Id = productItem.ID });
                }
                return lsProductViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<ProductsHomeViewModel>> GetAllProductsByDescriptionWithProxy(string description)
        {
            try
            {
                var lsProductViewModel = new List<ProductsHomeViewModel>();
                var payload = await _DbProducts.Product.Where(x => x.Description.Contains(description)).ToListAsync();
                foreach (var productItem in payload)
                {
                    lsProductViewModel.Add(new ProductsHomeViewModel { Description = productItem.Description, TypeProduct = productItem.Type.TypeName, Id = productItem.ID });
                }
                return lsProductViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<EditProductEditViewModel> GetProductById(Guid id)
        {
            var payload = await GetOneEntity(id);
            var dataMapped = new EditProductEditViewModel();
            if (payload != null)
            {
                dataMapped.TypeProduct = payload.Type.Description;
                dataMapped = _Mapper.Map(payload, new EditProductEditViewModel { TypeProduct = payload.Type.Description });
            }
            return dataMapped;
        }
        public async Task<ResponsePayload> UpdateProductInformation(EditProductEditViewModel data)
        {
            var payload = await UpdateEntity(data, data.ID);
            return payload;
        }
    }
}
