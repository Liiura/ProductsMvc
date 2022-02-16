using AutoMapper;
using ProductsStore.Data.Models;
using ProductsStore.Presentation.AdminViewModels;
using ProductsStore.Presentation.SharedViewModels;

namespace ProductsStore.Data.Mapper
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
