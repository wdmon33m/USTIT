using AutoMapper;
using USTITAPI.Models.BasicData;
using USTITAPI.Models.BasicData.CreateDto;
using USTITAPI.Models.BasicData.Dto;
using USTITAPI.Models.BasicData.UpdateDto;

namespace USTITAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();

            //CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            //CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            //CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
