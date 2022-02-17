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

            CreateMap<Product, EditProductEditViewModel>()
                .ForPath(
                dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.TypeName))
                .ForMember(
                dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(
                dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(
                dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(
                dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(
                dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId))
                .ForMember(
                dest => dest.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<EditProductEditViewModel, Product>()
                .ForMember(
                dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(
                dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(
                dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(
                dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(
                dest => dest.TypeId, opt => opt.MapFrom(src => src.TypeId))
                .ForMember(
                dest => dest.Value, opt => opt.MapFrom(src => src.Value));

            CreateMap<EditProductEditViewModel, ProductsHomeViewModel>().ReverseMap();

            CreateMap<Product, ProductsHomeViewModel>()
                .ForMember(
                dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(
                dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                .ForPath(
                dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.TypeName));
        }
    }
}
