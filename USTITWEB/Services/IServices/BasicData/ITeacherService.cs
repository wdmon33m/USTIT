using USTIT.WEB.Areas.BasicData.Models.Dto;

namespace USTIT.WEB.Services.IServices.BasicData
{
    public interface ITeacherService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(string teacherNo);
        Task<T> CreateAsync<T>(TeacherDto dto);
        Task<T> UpdateAsync<T>(TeacherDto dto);
        Task<T> DeleteAsync<T>(string teacherNo);
    }
}
