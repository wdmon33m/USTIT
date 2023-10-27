using AutoMapper;
using USTIT.Services.AuthAPI.Models;
using USTIT.Services.AuthAPI.Models.Dto;

namespace USTIT.Services.AuthAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, RegistrationRequestDto>().ReverseMap();

            CreateMap<ApplicationRole, RoleDto>().ReverseMap();

        }
    }
}
