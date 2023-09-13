using USTIT.WEB.Areas.BasicData.Models.CreateDto;
using USTIT.WEB.Areas.BasicData.Models.UpdateDto;
using USTIT.WEB.Models;

namespace USTIT.WEB.Areas.BasicData.Services.IServices
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
