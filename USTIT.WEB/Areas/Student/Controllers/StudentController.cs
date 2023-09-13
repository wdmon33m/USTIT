using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using USTIT.WEB.Areas.Student.Models;
using USTIT.WEB.Areas.Student.Services.IServices;
using USTIT.WEB.Models;

namespace USTIT.WEB.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public IActionResult IndexStudent()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll(string deptCode,int AcYear)
        {
            IEnumerable<StudentDto> list;

            APIResponse response = _studentServices.GetAllAsync<APIResponse>(deptCode,AcYear).GetAwaiter().GetResult();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<StudentDto>>(Convert.ToString(response.Result));
            }
            else
            {
                list = new List<StudentDto>();
            }
            return Json(new { data = list });
        }
    }
}
