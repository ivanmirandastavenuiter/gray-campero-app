using AutoMapper;
using GC.Dtos;
using GC.Models;

namespace GC.Profiles
{
    public class UsersProfile : Profile 
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
        }
    }
}