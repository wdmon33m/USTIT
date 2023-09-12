using AutoMapper;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Models.CreateDto;
using USTIT.Services.BasicDataAPI.Models.Dto;
using USTIT.Services.BasicDataAPI.Models.UpdateDto;

namespace USTIT.Services.BasicDataAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();

            CreateMap<Teacher, TeacherDto>().ReverseMap();

            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
