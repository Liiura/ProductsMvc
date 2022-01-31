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
                using (var context = _DbProducts)
                {
                    var model = _Mapper.Map(dataToMap, objectToInsert);
                    await context.Set<T>().AddAsync(model);
                    await context.SaveChangesAsync();
                    response.IsSuccess = true;
                    return response;
                }
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
                using (var context = _DbProducts)
                {
                    var dataToDelete = await GetOneEntity(id);
                    context.Set<T>().Remove(dataToDelete);
                    await context.SaveChangesAsync();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }
        public virtual async Task<T> GetOneEntity(Guid id)
        {
            using (var context = _DbProducts)
            {
                return await context.Set<T>().FindAsync(id);
            }
        }
        public virtual async Task<List<T>> GetAllEntity(Guid id)
        {
            using (var context = _DbProducts)
            {
                return await context.Set<T>().ToListAsync();
            }
        }
        public virtual async Task<ResponsePayload> UpdateEntity(object dataToMap, Guid id)
        {
            var response = new ResponsePayload();
            try
            {
                using (var context = _DbProducts)
                {
                    var entityToUpdate = await GetOneEntity(id);
                    var model = _Mapper.Map(dataToMap, entityToUpdate);
                    context.Set<T>().Update(model);
                    await context.SaveChangesAsync();
                    response.IsSuccess = true;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Error = ex.ToString();
                return response;
            }
        }
    }
}
