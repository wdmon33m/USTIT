using AutoMapper;
using USTITWEB.Areas.BasicData.Models;
using USTITWEB.Areas.BasicData.Models.Dto;
using USTITWEB.Areas.BasicData.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using USTITWEB.Models;
using USTITWEB.Areas.BasicData.Models.CreateDto;

namespace USTITWEB.Areas.BasicData.Controllers
{
    [Area("BasicData")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public CourseController(ICourseService courseService,IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexCourse()
        {
            List<CourseDto> listCourses = new();

            var response = await _courseService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                listCourses = JsonConvert.DeserializeObject<List<CourseDto>>(Convert.ToString(response.Result));
            }
            return View(listCourses);
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

        //public async Task<IActionResult> UpdateVilla(int villaId)
        //{
        //    var response = await _villaService.GetAsync<APIResponse>(villaId);
        //    if (response != null && response.IsSuccess)
        //    {
        //        VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
        //        return View(_mapper.Map<VillaUpdateDTO>(model));
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _villaService.UpdateAsync<APIResponse>(model);
        //        if (response != null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Villa updated successfully";
        //            return RedirectToAction(nameof(IndexVilla));
        //        }
        //    }
        //    TempData["error"] = "Error encountered";
        //    return View(model);
        //}

        //public async Task<IActionResult> DeleteVilla(int villaId)
        //{
        //    var response = await _villaService.GetAsync<APIResponse>(villaId);
        //    if (response != null && response.IsSuccess)
        //    {
        //        VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
        //        return View(model);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteVilla(VillaDTO model)
        //{
        //    var response = await _villaService.DeleteAsync<APIResponse>(model.Id);
        //    if (response != null && response.IsSuccess)
        //    {
        //            TempData["success"] = "Villa deleted successfully";
        //        return RedirectToAction(nameof(IndexVilla));
        //    }

        //    TempData["error"] = "Error encountered";
        //    return View(model);
        //}
    }
}
