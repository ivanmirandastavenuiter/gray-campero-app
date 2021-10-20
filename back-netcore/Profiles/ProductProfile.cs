using AutoMapper;
using GC.Dtos;
using GC.Models;

namespace GC.Profiles
{
    public class ProductProfile : Profile 
    {
        public ProductProfile()
        {
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
            CreateMap<Product, ProductReadDto>();
        }
    }
}