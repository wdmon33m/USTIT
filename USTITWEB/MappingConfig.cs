using AutoMapper;
using USTITWEB.Areas.BasicData.Models.CreateDto;
using USTITWEB.Areas.BasicData.Models.Dto;
using USTITWEB.Areas.BasicData.Models.UpdateDto;
using USTITWEB.Areas.BasicData.Services;
using USTITWEB.Areas.BasicData.Services.IServices;

namespace USTITWEB
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
