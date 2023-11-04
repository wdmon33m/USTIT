using Microsoft.IdentityModel.Tokens;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Service
{
    public class BasicDataService : IBasicDataService
    {
        private readonly IClassService _classService;
        private readonly IDepartmentService _departmentService;
        private readonly APIResponse _response;
        public BasicDataService(IClassService classService, IDepartmentService departmentService)
        {
            _classService = classService;
            _response = new();
            _departmentService = departmentService;
        }

        public async Task<APIResponse> CheckBasicData(SearchFilterDto filterDto)
        {
            try
            {
                DepartmentDto departmentObj = await _departmentService.GetAsync(filterDto.DeptCode);
                if (departmentObj is null)
                {
                    return _response.NotFound("Department is not exist!");
                }

                if (filterDto.AcYear < 2000 || filterDto.AcYear > DateTime.Now.Year)
                {
                    return _response.NotFound("Please enter year btween 2000 and " + DateTime.Now.Year);
                }

                ClassDto classObj = await _classService.GetAsync(filterDto.ClassNo);
                if (classObj is null)
                {
                    return _response.NotFound("Class no is not exist!");
                }

                List<int> semesterList = new List<int>() { filterDto.ClassNo * 2 - 1, filterDto.ClassNo * 2 };
                if (!semesterList.Contains(filterDto.SemNo) && filterDto.SemNo > 0)
                {
                    return _response.NotFound("Semester shoud be " + String.Join(" or ", semesterList));
                }
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }

        public async Task<IEnumerable<ClassDto>> GetClasses(string deptCode)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SemesterDto>> GetSemesteres(int classNo)
        {
            throw new NotImplementedException();
        }
    }
}
