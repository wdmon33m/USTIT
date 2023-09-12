using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using USTIT.Services.StudentAPI.Models;
using USTIT.Services.StudentAPI.Models.Dto;
using USTIT.Services.StudentAPI.Repository.IRepository;
using USTIT.Services.StudentAPI.Service.IService;
using USTIT.Services.StudentAPI.Utility;

namespace USTIT.Services.StudentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/student")]
    [ApiVersion("1.0")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _db;
        private readonly IDepartmentService _departmentService;

        private readonly IMapper _mapper;
        protected APIResponse _response;

        public StudentController(IStudentRepository db, IMapper mapper, IDepartmentService departmentService)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
            _departmentService = departmentService;
        }

        [HttpGet("{deptCode},{acYear}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> Get(string deptCode, int acYear)
        {
            try
            {
                var deptResponse = await _departmentService.GetAsync(deptCode);

                if (deptResponse.IsEmpty())
                {
                    return _response.NotFound("Department is not exist!");
                }

                if (acYear.IsEmpty() || acYear <= 2000 || acYear > DateTime.Now.Year)
                {
                    return _response.BadRequest("Pleace enter correct year");
                }

                IEnumerable<Student> studentsList = await _db.GetAllAsync(filter : s => s.DeptCode == deptCode && s.AcYear == acYear);

                if (studentsList.IsEmpty())
                {
                    return _response.NotFound();
                }

                _response.Result = _mapper.Map<List<Student>>(studentsList);
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
