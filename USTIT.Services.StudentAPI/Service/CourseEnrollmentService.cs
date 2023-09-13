using Newtonsoft.Json;
using USTIT.Services.StudentAPI.Models;
using USTIT.Services.StudentAPI.Models.Dto;
using USTIT.Services.StudentAPI.Service.IService;

namespace USTIT.Services.StudentAPI.Service
{
    public class CourseEnrollmentService : ICourseEnrollmentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CourseEnrollmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<CourseEnrollmentDto>> GetAllAsync(string deptCode, int acYear, int SemNo)
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/v1/courseEnrollment");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<CourseEnrollmentDto>>(Convert.ToString(resp.Result));
            }
            return null;
        }

        public async Task<CourseEnrollmentDto> GetAsync(string deptCode, int acYear, int SemNo)
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/v1/courseEnrollment/deptCode=" + deptCode + "/acYear=" + acYear + "/classNo="  + SemNo );
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);


            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CourseEnrollmentDto>(Convert.ToString(resp.Result));
            }

            return null;
        }
    }
}
