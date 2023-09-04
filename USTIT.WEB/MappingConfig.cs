using AutoMapper;
using USTIT.WEB.Areas.BasicData.Models.CreateDto;
using USTIT.WEB.Areas.BasicData.Models.Dto;
using USTIT.WEB.Areas.BasicData.Models.UpdateDto;

namespace USTIT.WEB
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<CourseDto, CourseCreateDto>().ReverseMap();
            CreateMap<CourseDto, CourseUpdateDto>().ReverseMap();
        }
    }
}
