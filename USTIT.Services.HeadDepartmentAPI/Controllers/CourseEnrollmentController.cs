using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Issuing;
using System.Net;
using USTIT.Services.BasicDataAPI.Models.Dto;
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
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                IEnumerable<CourseEnrollment> coursesList = await _db.GetAllAsync();

                if (coursesList == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                IEnumerable<TeacherDto> teacherDto = await _teacherService.GetAllAsync();

                foreach (var item in coursesList)
                {
                    item.Teacher = teacherDto.FirstOrDefault(u => u.TeacherNo == item.TeacherNo);
                }

                _response.Result = _mapper.Map<List<CourseEnrollmentDto>>(coursesList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            return _response;
        }
    }
}
