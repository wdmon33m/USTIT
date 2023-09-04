using USTIT.WEB.Areas.BasicData.Models.Dto;
using USTIT.WEB.Services.IServices.BasicData;
using USTIT.WEB.Utility;
using USTIT.WEB.Models;

namespace USTIT.WEB.Services.BasicData
{
    public class TeacherService : BaseService, ITeacherService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apiUrl;
        private const string apiVersion = "v1";

        public TeacherService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            apiUrl = configuration.GetValue<string>("ServiceUrls:USTAPI") + "/api/" + apiVersion + "/teacher";

        }

        public Task<T> CreateAsync<T>(TeacherDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync<T>(string teacherNo)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl
            });
        }

        public Task<T> GetAsync<T>(string teacherNo)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync<T>(TeacherDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
