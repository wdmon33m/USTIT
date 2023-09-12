using USTIT.Services.StudentAPI.Models.Dto;

namespace USTIT.Services.StudentAPI.Service.IService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> GetAsync(string deptCode);
    }
}
