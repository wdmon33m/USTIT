using USTIT.Services.StudentAPI.Models.Dto;

namespace USTIT.Services.StudentAPI.Service.IService
{
    public interface ICourseEnrollmentService
    {
        Task<IEnumerable<CourseEnrollmentDto>> GetAllAsync(string deptCode, int acYear, int SemNo);
        Task<CourseEnrollmentDto> GetAsync(string deptCode,int acYear, int SemNo);
    }
}
