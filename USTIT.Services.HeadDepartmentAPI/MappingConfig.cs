using AutoMapper;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Absence, AbsenceDto>().ReverseMap();
        }
    }
}
