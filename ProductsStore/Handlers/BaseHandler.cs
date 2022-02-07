using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsStore.ContextDB;
using ProductsStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsStore.Handlers
{
    public class BaseHandler<T> where T : class
    {
        private readonly ProductsContext _DbProducts;
        private readonly IMapper _Mapper;
        public BaseHandler(ProductsContext _dbProduts, IMapper mapper)
        {
            _DbProducts = _dbProduts;
            _Mapper = mapper;
        }
        public virtual async Task<ResponsePayload> InsertEntity(object dataToMap, T objectToInsert)
        {
            var response = new ResponsePayload();
            try
            {
                var model = _Mapper.Map(dataToMap, objectToInsert);
                await _DbProducts.Set<T>().AddAsync(model);
                await _DbProducts.SaveChangesAsync();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }
        public virtual async Task<ResponsePayload> DeleteOneEntity(Guid id)
        {
            var response = new ResponsePayload();
            try
            {
                var dataToDelete = await GetOneEntity(id);
                _DbProducts.Set<T>().Remove(dataToDelete);
                await _DbProducts.SaveChangesAsync();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }
        public virtual async Task<T> GetOneEntity(Guid id)
        {
            var data = await _DbProducts.Set<T>().FindAsync(id);
            return data;
        }
        public virtual async Task<List<T>> GetAllEntities()
        {
            var data = await _DbProducts.Set<T>().ToListAsync();
            return data;
        }
        public virtual async Task<ResponsePayload> UpdateEntity(object dataToMap, Guid id)
        {
            var response = new ResponsePayload();
            try
            {
                var entityToUpdate = await GetOneEntity(id);
                var model = _Mapper.Map(dataToMap, entityToUpdate);
                _DbProducts.Set<T>().Update(model);
                await _DbProducts.SaveChangesAsync();
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }
    }
}
