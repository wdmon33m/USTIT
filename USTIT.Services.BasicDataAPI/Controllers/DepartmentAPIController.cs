using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using USTIT.Services.BasicDataAPI.Repository.IRepository;
using AutoMapper;
using USTIT.Services.BasicDataAPI.Models;
using System.Net;
using USTIT.Services.BasicDataAPI.Models.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace USTIT.Services.BasicDataAPI.Controllers
{
    [Route("api/v{version:apiVersion}/department")]
    [ApiVersion("1.0")]
    [ApiController]
    public class DepartmentAPIController : ControllerBase
    {
        private readonly IDepartmentRepository _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public DepartmentAPIController(IDepartmentRepository db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                IEnumerable<Department> departmentsList = await _db.GetAllAsync();

                if (departmentsList == null)
                {
                    return _response.NotFound();
                }

                _response.Result = _mapper.Map<List<DepartmentDto>>(departmentsList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }

        [HttpGet("{deptCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Get(string deptCode)
        {
            try
            {
                Department department = await _db.GetAsync(d => d.DeptCode == deptCode);

                if (department == null)
                {
                    return _response.NotFound("Department is Not Exist!");
                }

                _response.Result = _mapper.Map<DepartmentDto>(department);
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
