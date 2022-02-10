using AutoMapper;
using ProductsStore.Areas.Admin.Data;
using ProductsStore.Models;
using ProductsStore.ViewModels;

namespace ProductsStore.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<UserClient, UserViewModel>().ReverseMap();
            CreateMap<Product, CreateProductEditViewModel>().ReverseMap();
            CreateMap<Product, EditProductEditViewModel>().ReverseMap();
            CreateMap<EditProductEditViewModel, ProductsHomeViewModel>().ReverseMap();
        }
    }
}
