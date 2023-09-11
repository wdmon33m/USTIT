using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.StudentAPI.Models;
using USTIT.Services.StudentAPI.Repository.IRepository;

namespace USTIT.Services.StudentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/student")]
    [ApiVersion("1.0")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _db;

        private readonly IMapper _mapper;
        protected APIResponse _response;

        public StudentController(IStudentRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
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
                IEnumerable<Student> studentsList = await _db.GetAllAsync();//paginationFilter:validFilter);

                response.PageNumber = filter.PageNumber;
                response.PageSize = filter.PageSize;

                if (studentsList == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }

                response.Result = _mapper.Map<List<Student>>(studentsList);
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
