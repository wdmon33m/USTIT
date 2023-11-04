using AutoMapper;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Models.Dto.Create;

namespace USTIT.Services.HeadDepartmentAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Absence, AbsenceDto>().ReverseMap();
            CreateMap<CourseEnrollment, CourseEnrollmentDto>().ReverseMap();
            CreateMap<LectureSchedule, LectureScheduleDto>().ReverseMap();
            CreateMap<LectureSchedule, CreateLectureScheduleDto>().ReverseMap();
            CreateMap<LectureTime, LectureTimeDto>().ReverseMap();
            CreateMap<StudentGroup, StudentGroupDto>().ReverseMap();
        }
    }
}
