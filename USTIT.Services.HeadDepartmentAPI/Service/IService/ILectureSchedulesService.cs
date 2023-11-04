using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Models.Dto.Create;

namespace USTIT.Services.HeadDepartmentAPI.Service.IService
{
    public interface ILectureSchedulesService
    {
        Task<APIResponse> GetAll(SearchFilterDto filterDto);
        Task<APIResponse> Create(CreateLectureScheduleDto dto);
    }
}
