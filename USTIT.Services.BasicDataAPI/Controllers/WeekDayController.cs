using Microsoft.AspNetCore.Mvc;
using USTIT.Services.BasicDataAPI.Repository.IRepository;
using AutoMapper;
using USTIT.Services.BasicDataAPI.Models;
using System.Net;
using USTIT.Services.BasicDataAPI.Models.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace USTIT.Services.BasicDataAPI.Controllers
{
    [Route("api/v{version:apiVersion}/day")]
    [ApiVersion("1.0")]
    [ApiController]
    public class WeekDayController : ControllerBase
    {
        private readonly IWeekDayRepository _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public WeekDayController(IWeekDayRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                IEnumerable<WeekDay> weekDaysList = await _db.GetAllAsync();

                if (weekDaysList == null)
                {
                    return _response.NotFound();
                }

                _response.Result = _mapper.Map<List<WeekDayDto>>(weekDaysList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            try
            {
                WeekDay day = await _db.GetAsync(d => d.Id == id);

                if (day == null)
                {
                    return _response.NotFound("Day is Not Exist!");
                }

                _response.Result = _mapper.Map<WeekDayDto>(day);
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
