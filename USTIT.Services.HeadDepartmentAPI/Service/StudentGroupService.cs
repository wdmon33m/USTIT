using System.Linq.Expressions;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Service
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IStudentGroupRepository _db;
        private readonly APIResponse _response;
        public StudentGroupService(IStudentGroupRepository db)
        {
            _db = db;
            _response = new();
        }

        public async Task<APIResponse> GetAll(SearchFilterDto filterDto)
        {
            try
            {
                var ExpressionFilter = GetFilter(filterDto);
                var groupsList = await _db.GetAllAsync(filter: ExpressionFilter);
                if (groupsList == null)
                {
                    return _response.NotFound();
                }

                _response.Result = groupsList;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }

        private static Expression<Func<StudentGroup, bool>> GetFilter(SearchFilterDto filterDto)
        {
            Expression<Func<StudentGroup, bool>>? ExpressionFilter = s => s.DeptCode == filterDto.DeptCode.ToUpper() && s.AcYear == filterDto.AcYear
                                     && s.ClassNo == filterDto.ClassNo;

            if (filterDto.SemNo > 0)
            {
                ExpressionFilter = s => s.DeptCode == filterDto.DeptCode.ToUpper() && s.AcYear == filterDto.AcYear
                                    && s.ClassNo == filterDto.ClassNo && s.SemNo == filterDto.SemNo;
            }

            return ExpressionFilter;
        }
    }
}
