using AutoMapper;
using UserCompany.Model.Models;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
        }
    }
}
