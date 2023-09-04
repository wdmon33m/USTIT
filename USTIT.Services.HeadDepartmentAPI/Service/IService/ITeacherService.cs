using USTIT.Services.BasicDataAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI.Service.IService
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();
        Task<TeacherDto> GetAsync(string teacherNo);
    }
}
