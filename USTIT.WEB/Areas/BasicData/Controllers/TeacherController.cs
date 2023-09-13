using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using USTIT.WEB.Areas.BasicData.Models.Dto;
using USTIT.WEB.Areas.BasicData.Services.IServices;
using USTIT.WEB.Models;

namespace USTIT.WEB.Areas.BasicData.Controllers
{
    [Area("BasicData")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public IActionResult IndexTeacher()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            IEnumerable<TeacherDto> list;

            APIResponse response = _teacherService.GetAllAsync<APIResponse>().GetAwaiter().GetResult();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<TeacherDto>>(Convert.ToString(response.Result));
            }
            else
            {
                list = new List<TeacherDto>();
            }
            return Json(new { data = list });
        }
    }
}
