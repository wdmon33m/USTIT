using USTITWEB.Areas.BasicData.Models.CreateDto;
using USTITWEB.Areas.BasicData.Models.UpdateDto;
using USTITWEB.Models;

namespace USTITWEB.Areas.BasicData.Services.IServices
{
    public interface ICourseService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(string coursecode);
        Task<T> CreateAsync<T>(CourseCreateDto dto);
        Task<T> UpdateAsync<T>(CourseUpdateDto dto);
        Task<T> DeleteAsync<T>(string coursecode);
    }
}
