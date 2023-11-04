using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/StudentGroup")]
    [ApiVersion("1.0")]
    [ApiController]
    public class StudentGroupController : ControllerBase
    {
        private readonly IBasicDataService _basicDataService;
        private readonly IStudentGroupService _studentGroupService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public StudentGroupController(IStudentGroupService courseEnrollmentService, IMapper mapper,
                                      IBasicDataService basicDataService)
        {
            _mapper = mapper;
            _response = new();
            _studentGroupService = courseEnrollmentService;
            _basicDataService = basicDataService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Get([FromQuery] SearchFilterDto dto)
        {
            try
            {
                var response = await _basicDataService.CheckBasicData(dto);
                if (!response.IsSuccess)
                {
                    return response;
                }

                var studentGroupsResponse = await _studentGroupService.GetAll(dto);
                if (!studentGroupsResponse.IsSuccess)
                {
                    return studentGroupsResponse;
                }

                _response.Result = _mapper.Map<List<StudentGroupDto>>(studentGroupsResponse.Result);
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
