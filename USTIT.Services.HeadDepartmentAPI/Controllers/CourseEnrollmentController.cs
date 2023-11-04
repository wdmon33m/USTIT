using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/courseEnrollment")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CourseEnrollmentController : ControllerBase
    {
        private readonly IBasicDataService _basicDataService;
        private readonly ICourseEnrollmentService _courseEnrollmentService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public CourseEnrollmentController(IMapper mapper, ICourseEnrollmentService courseEnrollmentService, 
            IBasicDataService basicDataService)
        {
            _mapper = mapper;
            _response = new();
            _courseEnrollmentService = courseEnrollmentService;
            _basicDataService = basicDataService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Get([FromQuery] SearchFilterDto dto)
        {
            try
            {
                var response = await _basicDataService.CheckBasicData(dto);
                if (!response.IsSuccess)
                {
                    return response;
                }

                var coursesResponse = await _courseEnrollmentService.GetAll(dto);
                if (!coursesResponse.IsSuccess)
                {
                    return coursesResponse;
                }

                _response.Result = _mapper.Map<List<CourseEnrollmentDto>>(coursesResponse.Result);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }
    }
}
