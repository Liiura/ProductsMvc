using AutoMapper;
using ProductsStore.Models;
using ProductsStore.ViewModels;

namespace ProductsStore.Mapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<UserClient, UserViewModel>().ReverseMap();
        }
    }
}
