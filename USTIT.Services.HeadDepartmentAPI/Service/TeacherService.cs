using Newtonsoft.Json;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeacherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/v1/teacher");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<TeacherDto>>(Convert.ToString(resp.Result));
            }
            return new List<TeacherDto>(); 
        }

        public async Task<TeacherDto> GetAsync(string teacherNo)
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/teacher/" + teacherNo);
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<TeacherDto>(Convert.ToString(resp.Result));
            }
            return new TeacherDto();
        }
    }
}
