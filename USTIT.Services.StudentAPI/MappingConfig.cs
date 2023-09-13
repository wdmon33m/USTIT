using AutoMapper;
using USTIT.Services.StudentAPI.Models.Dto;
using USTIT.Services.StudentAPI.Models;

namespace USTIT.Services.StudentAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<StudentHeader, StudentHeaderDto>().ReverseMap();
            CreateMap<StudentNames, StudentNamesDto>().ReverseMap();

            //CreateMap<Student, StudentDto>()
            //    .ForMember(dest => dest.StudentNames, u => u.MapFrom(src => src.StudentNames))
            //    .ReverseMap();
        }
    }
}
