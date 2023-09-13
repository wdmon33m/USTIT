using System;
using USTIT.WEB.Services;
using USTIT.WEB.Models;
using USTIT.WEB.Areas.BasicData.Models.CreateDto;
using USTIT.WEB.Areas.BasicData.Models.UpdateDto;
using USTIT.WEB.Utility;
using USTIT.WEB.Areas.BasicData.Services.IServices;

namespace USTIT.WEB.Areas.BasicData.Services
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apiUrl;
        private const string apiVersion = "v1";
        public CourseService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            apiUrl = configuration.GetValue<string>("ServiceUrls:USTAPI") + "/api/" + apiVersion + "/course";

        }

        public Task<T> CreateAsync<T>(CourseCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = apiUrl
            });
        }

        public Task<T> DeleteAsync<T>(string coursecode)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = apiUrl + "/" + coursecode
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl
            });
        }

        public Task<T> GetAsync<T>(string coursecode)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl + "/" + coursecode
            });
        }
        public Task<T> UpdateAsync<T>(CourseUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = apiUrl + "/" + dto.CourseCode
            });
        }
    }
}
