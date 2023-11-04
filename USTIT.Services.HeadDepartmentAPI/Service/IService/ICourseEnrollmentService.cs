using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;

namespace USTIT.Services.HeadDepartmentAPI.Service.IService
{
    public interface ICourseEnrollmentService
    {
        Task<APIResponse> GetAll(SearchFilterDto filterDto);
    }
}
