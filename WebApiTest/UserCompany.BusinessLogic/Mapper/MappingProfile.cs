using AutoMapper;
using UserCompany.Model.Models;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User,CreateUserViewModel>().ReverseMap();
            CreateMap<User, UpdateUserViewModel>().ReverseMap();
        }
    }
}
