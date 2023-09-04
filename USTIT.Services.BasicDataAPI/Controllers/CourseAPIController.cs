using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using USTIT.Services.BasicDataAPI.Models;
using USTIT.Services.BasicDataAPI.Models.CreateDto;
using USTIT.Services.BasicDataAPI.Models.Dto;
using USTIT.Services.BasicDataAPI.Models.UpdateDto;
using USTIT.Services.BasicDataAPI.Data;
using USTIT.Services.BasicDataAPI.Repository.IRepository;


namespace USTIT.Services.BasicDataAPI.Controllers
{
    [Route("api/v{version:apiVersion}/course")]
    [ApiVersion("1.0")]
    [ApiController]
    public class CourseAPIController : ControllerBase
    {
        private readonly ICourseRepository _db;
        protected APIResponse _response;
        private readonly IMapper _mapper;

        public CourseAPIController(ICourseRepository dbCourse, IMapper mapper)
        {
            _db = dbCourse;
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
                IEnumerable<Course> coursesList = await _db.GetAllAsync();

                if (coursesList == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return _response;
                }

                _response.Result = _mapper.Map<List<CourseDto>>(coursesList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpGet("{coursecode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetCourse(string coursecode)
        {
            try
            {
                if (coursecode.IsNullOrEmpty())
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "Please enter a course code" };
                    return _response;
                }

                var course = await _db.GetAsync(v => v.CourseCode == coursecode);

                if (course == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { "The course is not exist!" };
                    return _response;
                }

                _response.Result = _mapper.Map<CourseDto>(course);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateCourse([FromBody] CourseCreateDto createDTO)
        {
            try
            {
                if (await _db.GetAsync(u => u.CourseCode.ToLower() == createDTO.CourseCode.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "This Course Code Already Exists!" };
                    return _response;
                }
                if (await _db.GetAsync(u => u.CourseTitle.ToLower() == createDTO.CourseTitle.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "This Course Already Exists!" };
                    return _response;
                }

                if (createDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return _response;
                }

                Course course = _mapper.Map<Course>(createDTO);
                course.CreationDate = DateTime.Now;

                await _db.CreateAsync(course);

                _response.Result = course;
                _response.StatusCode = HttpStatusCode.Created;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return _response;
        }

        [HttpDelete("{coursecode}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteCourse(string coursecode)
        {
            try
            {
                if (coursecode.IsNullOrEmpty())
                {
                    _response.ErrorMessages = new List<string>() { "Please enter course code" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return _response;
                }

                var course = await _db.GetAsync(u => u.CourseCode == coursecode);

                if (course == null)
                {
                    _response.ErrorMessages = new List<string>() { "The course is not exists!" };
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return _response;
                }

                await _db.RemoveAsync(course);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = "Course has been deleted successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            return _response;
        }

        [HttpPut("{coursecode}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> UpdateCourse(string coursecode, [FromBody] CourseUpdateDto courseDTO)
        {
            try
            {
                if (coursecode.IsNullOrEmpty() || coursecode != courseDTO.CourseCode)
                {
                    if (coursecode.IsNullOrEmpty())
                        _response.ErrorMessages = new List<string>() { "Please enter course code" };
                    else
                        _response.ErrorMessages = new List<string>() { "Course code shoud be same" };

                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return _response;
                }

                if (await _db.GetAsync(u => u.CourseCode.ToLower() == courseDTO.CourseCode.ToLower(), tracked: false) == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "This Course is not Exists!" };
                    return _response;
                }
                if (await _db.GetAsync(u => u.CourseTitle.ToLower() == courseDTO.CourseTitle.ToLower()) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "The Course Title Already Exists!" };
                    return _response;
                }

                Course model = _mapper.Map<Course>(courseDTO);


                _response.Result = await _db.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
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
