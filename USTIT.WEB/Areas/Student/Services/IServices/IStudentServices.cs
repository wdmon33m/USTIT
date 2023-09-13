using USTIT.WEB.Areas.Student.Models;

namespace USTIT.WEB.Areas.Student.Services.IServices
{
    public interface IStudentServices
    {
        Task<T> GetAllAsync<T>(string deptCode,int acYear);
        Task<T> GetAsync<T>(string fullStdId);
        Task<T> CreateAsync<T>(StudentDto dto);
        Task<T> UpdateAsync<T>(StudentDto dto);
        Task<T> DeleteAsync<T>(string fullStdId);
    }
}
