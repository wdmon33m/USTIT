using AutoMapper;
using USTITWEB.Areas.BasicData.Models;
using USTITWEB.Areas.BasicData.Models.Dto;
using USTITWEB.Areas.BasicData.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using USTITWEB.Models;
using USTITWEB.Areas.BasicData.Models.CreateDto;
using USTIT.WEB.Utility;

namespace USTIT.WEB.Areas.BasicData.Controllers
{
    [Area("BasicData")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> IndexCourse()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            IEnumerable<CourseDto> list;

            APIResponse response = _courseService.GetAllAsync<APIResponse>().GetAwaiter().GetResult();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CourseDto>>(Convert.ToString(response.Result));
            }
            else
            {
                list = new List<CourseDto>();
            }
            return Json(new { data = list });
        }

        public async Task<IActionResult> CreateCourse()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse(CourseCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _courseService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa created successfully";
                    return RedirectToAction(nameof(IndexCourse));
                }
            }
            TempData["error"] = "Error encountered";
            return View(model);
        }

    }
}
