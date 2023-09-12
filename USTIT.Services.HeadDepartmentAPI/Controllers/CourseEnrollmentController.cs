using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public CourseEnrollmentController(ICourseEnrollmentRepository db, IMapper mapper, ITeacherService teacherService)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
            _teacherService = teacherService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResponse>> Get([FromQuery] PaginationFilter filter)
        {
            PagedResponse response = new();
            
            try
            {
                //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                IEnumerable<CourseEnrollment> coursesList = await _db.GetAllAsync();//paginationFilter:validFilter);
                
                response.PageNumber = filter.PageNumber;
                response.PageSize = filter.PageSize;

                if (coursesList == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
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
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }
    }
}
