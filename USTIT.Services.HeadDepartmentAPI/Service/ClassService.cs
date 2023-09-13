using Newtonsoft.Json;
using USTIT.Services.HeadDepartmentAPI.Models;
using USTIT.Services.HeadDepartmentAPI.Models.Dto;
using USTIT.Services.HeadDepartmentAPI.Service.IService;

namespace USTIT.Services.HeadDepartmentAPI.Service
{
    public class ClassService : IClassService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ClassService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<ClassDto>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/v1/class");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ClassDto>>(Convert.ToString(resp.Result));
            }
            return null;
        }

        public async Task<ClassDto> GetAsync(int classNo)
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/v1/class/" + classNo);
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<ClassDto>(Convert.ToString(resp.Result));
            }
            return null;
        }
    }
}
