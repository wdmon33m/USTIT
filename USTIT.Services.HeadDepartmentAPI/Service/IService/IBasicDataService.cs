using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI.Service.IService
{
    public interface IBasicDataService
    {
        Task<IEnumerable<DepartmentDto>> GetDepartments();
        Task<IEnumerable<ClassDto>> GetClasses(string deptCode);
        Task<IEnumerable<SemesterDto>> GetSemesteres(int classNo);
        Task<APIResponse> CheckBasicData(SearchFilterDto filterDto);
    }
}
