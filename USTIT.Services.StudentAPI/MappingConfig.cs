using AutoMapper;
using USTIT.Services.StudentAPI.Models.Dto;
using USTIT.Services.StudentAPI.Models;

namespace USTIT.Services.StudentAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
