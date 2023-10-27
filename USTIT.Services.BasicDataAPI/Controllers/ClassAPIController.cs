using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Models.Dto;
using USTIT.Services.BasicDataAPI.Repository.IRepository;
using USTIT.Services.BasicDataAPI.Utility;

namespace USTIT.Services.BasicDataAPI.Controllers
{
    [Route("api/v{version:apiVersion}/class")]
    [ApiVersion("1.0")]
    [ApiController]

    public class ClassAPIController : ControllerBase
    {
        private readonly IClassRepository _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;

        public ClassAPIController(IMapper mapper, IClassRepository db)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var classesList = _db.GetAllAsync();

                if (classesList.IsEmpty())
                {
                    return _response.NoContent();
                }

                _response.Result = _mapper.Map<List<ClassDto>>(classesList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }

        [HttpGet("{classNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Get(int classNo)
        {
            try
            {
                Class obj = _db.GetAsync(e => e.ClassNo == classNo);

                if (obj.IsEmpty())
                {
                    return _response.NoContent("Class is not exist!");
                }
                
                _response.Result = _mapper.Map<ClassDto>(obj);
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
