using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Repository.IRepository;

namespace USTIT.Services.HeadDepartmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/absence")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AbsenceAPIController : ControllerBase
    {
        private readonly IAbsenceRepository _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public AbsenceAPIController(IAbsenceRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                IEnumerable<Absence> teachersList = await _db.GetAllAsync();

                if (teachersList == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<List<AbsenceDto>>(teachersList);
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
