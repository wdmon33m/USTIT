using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using USTITAPI.Data;
using USTITAPI.Models.BasicData;
using USTITAPI.Models.BasicData.Dto;

namespace USTITAPI.Controllers.BasicData
{
    [Route("api/")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("Courses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CourseDto>> GetCourses()
        {
            return Ok(_db.Courses.ToList());
        }

        [HttpGet("Courses/{coursecode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CourseDto> GetCourse(string coursecode)
        {
            if (coursecode.IsNullOrEmpty()) return BadRequest();
            
            var course = _db.Courses.FirstOrDefault(c => c.CourseCode == coursecode);
            
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpPost("Courses")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CourseDto> CreateCourse([FromBody]CourseDto courseDTO)
        {
            if (_db.Courses.FirstOrDefault(c => c.CourseCode.ToLower() == courseDTO.CourseCode.ToLower()) != null)
            {
                ModelState.AddModelError("CUSTITomError","This course code already Exist!");
                return BadRequest(ModelState);
            }

            if (_db.Courses.FirstOrDefault(c => c.CourseTitle.ToLower() == courseDTO.CourseTitle.ToLower()) != null)
            {
                ModelState.AddModelError("CUSTITomError", "This course title already Exist!");
                return BadRequest(ModelState);
            }

            if (courseDTO == null) return BadRequest(courseDTO);

            Course model = new()
            {
                CourseCode = courseDTO.CourseCode,
                CourseTitle = courseDTO.CourseTitle,
                Notes = courseDTO.Notes,
                Description = courseDTO.Description,
                IsActive = true
            };
            _db.Courses.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("Courses", new { CourseCode = courseDTO.CourseCode }, courseDTO);
        }

        [HttpDelete("Courses/{coursecode}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CourseDto> DeleteCourse(string coursecode)
        {
            if (coursecode.IsNullOrEmpty()) return BadRequest();

            var course = _db.Courses.FirstOrDefault(c => c.CourseCode == coursecode);

            if (course == null) return NotFound();

            _db.Courses.Remove(course);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("Courses")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CourseDto> UpdateCourse(string coursecode, [FromBody] CourseDto courseDTO)
        {
            if (coursecode.IsNullOrEmpty() || coursecode != courseDTO.CourseCode) return BadRequest();

            Course model = new()
            {
                CourseCode = courseDTO.CourseCode,
                CourseTitle = courseDTO.CourseTitle,
                Notes = courseDTO.Notes,
                Description = courseDTO.Description,
                IsActive = courseDTO.IsActive
            };
            _db.Courses.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
