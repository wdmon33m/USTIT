using USTIT.WEB.Areas.HeadDepartment.Models;

namespace USTIT.WEB.Areas.HeadDepartment.Services.IServices
{
    public interface ICourseEnrollmentService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(string ceNo);
        Task<T> CreateAsync<T>(CourseEnrollmentDto dto);
        Task<T> UpdateAsync<T>(CourseEnrollmentDto dto);
        Task<T> DeleteAsync<T>(string coursecode);
    }
}
