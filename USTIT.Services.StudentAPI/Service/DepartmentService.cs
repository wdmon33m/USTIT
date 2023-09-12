using Newtonsoft.Json;
using USTIT.Services.StudentAPI.Models.Dto;
using USTIT.Services.StudentAPI.Models;
using USTIT.Services.StudentAPI.Service.IService;

namespace USTIT.Services.StudentAPI.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DepartmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/v1/department");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<DepartmentDto>>(Convert.ToString(resp.Result));
            }
            return null; 
        }

        public async Task<DepartmentDto> GetAsync(string deptCode)
        {
            var client = _httpClientFactory.CreateClient("BasicData");
            var response = await client.GetAsync($"/api/v1/department/" + deptCode);
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<APIResponse>(apiContent);
            

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<DepartmentDto>(Convert.ToString(resp.Result));
            }

            return null;
        }
    }
}
