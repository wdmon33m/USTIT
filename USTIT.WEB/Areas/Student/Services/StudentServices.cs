using USTIT.WEB.Areas.Student.Models;
using USTIT.WEB.Areas.Student.Services.IServices;
using USTIT.WEB.Models;
using USTIT.WEB.Services;
using USTIT.WEB.Utility;

namespace USTIT.WEB.Areas.Student.Services
{
    public class StudentServices : BaseService, IStudentServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apiUrl;
        private const string apiVersion = "v1";

        public StudentServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            apiUrl = configuration.GetValue<string>("ServiceUrls:StudentAPI") + "/api/" + apiVersion + "/student";
        }

        public Task<T> GetAllAsync<T>(string deptCode, int acYear)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl + "/{deptcode=" + deptCode + "},{acYear=" + acYear + "}" 
            });
        }

        public Task<T> GetAsync<T>(string fullStdId)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl + "/" + fullStdId
            });
        }

        public Task<T> CreateAsync<T>(StudentDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = apiUrl
            });
        }

        public Task<T> UpdateAsync<T>(StudentDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = apiUrl + "/" + dto.FullStdID
            });
        }

        public Task<T> DeleteAsync<T>(string fullStdId)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = apiUrl + "/" + fullStdId
            });
        }
    }
}
