using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/courseEnrollment")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly ICourseEnrollmentRepository _db;
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classService;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public CourseEnrollmentController(ICourseEnrollmentRepository db, IMapper mapper, ITeacherService teacherService, IClassService classService)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
            _teacherService = teacherService;
            _classService = classService;
        }


        [HttpGet("{deptCode}/{acYear}/{classNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResponse>> Get(string deptCode, int acYear, int classNo,[FromQuery] int semesterNo, [FromQuery] PaginationFilter filter)
        {
            PagedResponse response = new();
            
            try
            {
                ClassDto classObj = await _classService.GetAsync(classNo);
                if (classObj == null)
                {
                    response.NotFound("Class no is not exist");
                    return response;
                }

                List<int> semesterList = new List<int>() { classNo * 2 - 1,classNo * 2};
                if (!semesterList.Contains(semesterNo) && semesterNo > 0)
                {
                    response.NotFound("Semester shoud be " + String.Join(" or ",semesterList));
                    return response;
                }


                //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

                Expression<Func<CourseEnrollment, bool>>? ExpressionFilter  = s => s.DeptCode == deptCode.ToUpper() && s.AcYear == acYear && s.ClassNo == classNo;
                ;
                if (semesterNo > 0)
                {
                    ExpressionFilter = s => s.DeptCode == deptCode.ToUpper() && s.AcYear == acYear
                                                                  && s.ClassNo == classNo && s.SemNo == semesterNo;
                }
                
                var coursesList = await _db.GetAllAsync(filter:ExpressionFilter);//paginationFilter:validFilter);


                response.PageNumber = filter.PageNumber;
                response.PageSize = filter.PageSize;

                if (coursesList == null)
                {
                    response.NotFound();
                    return response;
                }

                //IEnumerable<TeacherDto> teacherDto = await _teacherService.GetAllAsync();

                //foreach (var item in coursesList)
                //{
                //    item.Teacher = teacherDto.FirstOrDefault(u => u.TeacherNo == item.TeacherNo);
                //}

                response.Result = _mapper.Map<List<CourseEnrollmentDto>>(coursesList);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.InternalServerError(ex.Message);
            }

            return response;
        }
    }
}
