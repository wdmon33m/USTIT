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
                    return _response.NotFound();
                }

                _response.Result = _mapper.Map<List<CourseDto>>(coursesList);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
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
                    return _response.BadRequest("Please enter a course code");
                }

                var course = await _db.GetAsync(v => v.CourseCode == coursecode);

                if (course == null)
                {
                    return _response.BadRequest("The course is not exist!");
                }

                _response.Result = _mapper.Map<CourseDto>(course);
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
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
                    return _response.BadRequest("This Course Code Already Exists!");
                }
                if (await _db.GetAsync(u => u.CourseTitle.ToLower() == createDTO.CourseTitle.ToLower()) != null)
                {
                    return _response.BadRequest("This Course Already Exists!");
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
                _response.InternalServerError(ex.Message);
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
                    return _response.BadRequest("Please enter course code");
                }

                var course = await _db.GetAsync(u => u.CourseCode == coursecode);

                if (course == null)
                {
                    return _response.NotFound("The course is not exists!");
                }

                await _db.RemoveAsync(course);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.Result = "Course has been deleted successfully";
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
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
                        return _response.BadRequest("Please enter course code");
                    else
                        return _response.BadRequest("Course code shoud be same");
                }

                if (await _db.GetAsync(u => u.CourseCode.ToLower() == courseDTO.CourseCode.ToLower(), tracked: false) == null)
                {
                    return _response.BadRequest("This Course is not Exists!");
                }
                if (await _db.GetAsync(u => u.CourseTitle.ToLower() == courseDTO.CourseTitle.ToLower()) != null)
                {
                    return _response.BadRequest("The Course Title Already Exists!");
                }

                Course model = _mapper.Map<Course>(courseDTO);


                _response.Result = await _db.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }

            return _response;
        }
    }
}
