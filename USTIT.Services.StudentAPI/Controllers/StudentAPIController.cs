using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Net;
using USTIT.Services.StudentAPI.Data;
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
    public class StudentAPIController : ControllerBase
    {
        private readonly IStudentRepository _dbStudent;
        private readonly IDepartmentService _departmentService;
        private readonly ICourseEnrollmentService _courseEnrollmentService;

        private readonly IMapper _mapper;
        protected APIResponse _response;

        public StudentAPIController(IStudentRepository dbStudent, IMapper mapper, IDepartmentService departmentService, ICourseEnrollmentService courseEnrollmentService)
        {
            _dbStudent = dbStudent;
            _mapper = mapper;
            _response = new();
            _departmentService = departmentService;
            _courseEnrollmentService = courseEnrollmentService;
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

                IEnumerable<StudentHeader> studentsList = await _dbStudent.GetAllAsync(filter : s => s.DeptCode == deptCode && s.AcYear == acYear);

                if (studentsList.IsEmpty())
                {
                    return _response.NotFound();
                }

                _response.Result = _mapper.Map<List<StudentHeaderDto>>(studentsList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }

        [HttpGet("getStudent/{deptCode},{acYear},{studentNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetStudent(string deptCode, int acYear, int studentNo)
        {
            try
            {
                var deptResponse = await _departmentService.GetAsync(deptCode);

                if (deptResponse.IsEmpty())
                {
                    return _response.NotFound("Department is not exist!");
                }

                if (acYear <= 2000 || acYear > DateTime.Now.Year)
                {
                    return _response.BadRequest("Pleace enter correct year");
                }

                if (studentNo <= 0)
                {
                    return _response.BadRequest("Pleace enter correct student number");
                }

                string fullStdId = acYear + deptCode.ToUpper() + studentNo.ToString().PadLeft(4, '0');

                StudentHeader student = await _dbStudent.GetAsync(filter: s => s.FullStdID == fullStdId.ToUpper());

                if (student.IsEmpty())
                {
                    return _response.NotFound("Student with id " + fullStdId + " is not exist!");
                }

                _response.Result = _mapper.Map<StudentHeaderDto>(student);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }

        [HttpGet("getByFullStdId/{fullStdId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetByFullStdId(string fullStdId)
        {
            try
            {
                StudentHeader student = await _dbStudent.GetAsync(s => s.FullStdID == fullStdId.ToUpper(),true,"StudentNames");

                if (student.IsEmpty())
                {
                    return _response.NotFound("Student with id " + fullStdId + " is not exist!");
                }

                StudentHeaderDto studentHeader = _mapper.Map<StudentHeaderDto>(student);

                _response.Result = studentHeader;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }

        [HttpGet("getAttendance/{fullStdId},{academicYear},{semesterNo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetAttendance(string fullStdId, int academicYear, int semesterNo)
        {
            try
            {
                var studentHeader = await _dbStudent.GetAsync(e => e.FullStdID == fullStdId);

                if (studentHeader.IsEmpty())
                {
                    return _response.NotFound("Student with id " + fullStdId + " is not exist!");
                }

                int classNo = (semesterNo % 2) == 0 ? semesterNo / 2 : semesterNo / 2 + 1 ;

                CourseEnrollmentDto courseDto = await _courseEnrollmentService.GetAsync(studentHeader.DeptCode, academicYear,semesterNo);

                _response.Result = _mapper.Map<IEnumerable<StudentHeaderDto>>(studentHeader);
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
