using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Models.Dto.Create;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/LectureSchedule")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LectureScheduleController : ControllerBase
    {
        private readonly IBasicDataService _basicDataService;
        private readonly ILectureSchedulesService _lectureScheduleService;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public LectureScheduleController(ILectureScheduleRepository db, IMapper mapper,
                    IBasicDataService basicDataService, ILectureSchedulesService lectureScheduleService)
        {
            _mapper = mapper;
            _response = new();
            _basicDataService = basicDataService;
            _lectureScheduleService = lectureScheduleService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Get([FromQuery] SearchFilterDto dto)
        {
            return await _lectureScheduleService.GetAll(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Post([FromBody] CreateLectureScheduleDto dto)
        {
            return await _lectureScheduleService.Create(dto);
        }
    }
}
