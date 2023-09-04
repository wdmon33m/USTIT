using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Models.Dto;
using USTIT.Services.BasicDataAPI.Repository.IRepository;

namespace USTIT.Services.BasicDataAPI.Controllers
{
    [Route("api/v{version:apiVersion}/teacher")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly ITeacherRepository _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public TeacherAPIController(ITeacherRepository db, IMapper mapper)
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
                IEnumerable<Teacher> teachersList = await _db.GetAllAsync();//(includeProperties: "AcademicDegrees");

                if (teachersList == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<List<TeacherDto>>(teachersList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

    }
}
