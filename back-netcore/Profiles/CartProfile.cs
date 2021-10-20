using AutoMapper;
using GC.Dtos;
using GC.Models;

namespace GC.Profiles
{
    public class CartProfile : Profile 
    {
        public CartProfile()
        {
            CreateMap<Cart, CartReadDto>();
            CreateMap<Cart, CartUpdateDto>();
            CreateMap<CartUpdateDto, Cart>();
            CreateMap<CartCreateInputDto, Cart>();
        }
    }
}