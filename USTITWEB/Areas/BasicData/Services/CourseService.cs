using System;
using USTITWEB.Services;
using USTITWEB.Areas.BasicData.Services.IServices;
using USTITWEB.Models;
using USTITWEB.Areas.BasicData.Models.CreateDto;
using USTITWEB.Areas.BasicData.Models.UpdateDto;
using USTIT.WEB.Utility;

namespace USTITWEB.Areas.BasicData.Services
{
    public class CourseService : BaseService, ICourseService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        private const string apiVersion = "v1";
        public CourseService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:USTAPI") + "/api/" + apiVersion + "/Courseapi";

        }

        public Task<T> CreateAsync<T>(CourseCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaUrl
            });
        }

        public Task<T> DeleteAsync<T>(string coursecode)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = villaUrl + "/" + coursecode
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl
            });
        }

        public Task<T> GetAsync<T>(string coursecode)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/" + coursecode
            });
        }
        public Task<T> UpdateAsync<T>(CourseUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/" + dto.CourseCode
            });
        }
    }
}
