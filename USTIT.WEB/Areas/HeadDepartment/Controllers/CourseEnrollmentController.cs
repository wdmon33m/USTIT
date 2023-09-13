using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using USTIT.WEB.Areas.HeadDepartment.Models;
using USTIT.WEB.Areas.HeadDepartment.Services.IServices;
using USTIT.WEB.Models;

namespace USTIT.WEB.Areas.HeadDepartment.Controllers
{
    [Area("HeadDepartment")]
    public class CourseEnrollmentController : Controller
    {
        private readonly ICourseEnrollmentService _courseEnrollmentService;

        public CourseEnrollmentController(ICourseEnrollmentService courseEnrollmentService)
        {
            _courseEnrollmentService = courseEnrollmentService;
        }

        public IActionResult IndexCourseEnrollment()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            IEnumerable<CourseEnrollmentDto> list;

            APIResponse response = _courseEnrollmentService.GetAllAsync<APIResponse>().GetAwaiter().GetResult();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CourseEnrollmentDto>>(Convert.ToString(response.Result));
            }
            else
            {
                list = new List<CourseEnrollmentDto>();
            }
            return Json(new { data = list });
        }
    }
}
