using USTITUtility;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using USTITWEB.Services;
using USTITWEB.Areas.BasicData.Services.IServices;
using USTITWEB.Models;
using USTITWEB.Areas.BasicData.Models.CreateDto;
using USTITWEB.Areas.BasicData.Models.UpdateDto;

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
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI") + "/api/" + apiVersion + "/VillaAPI";

        }

        public Task<T> CreateAsync<T>(CourseCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = dto,
                Url = villaUrl
            });
        }

        public Task<T> DeleteAsync<T>(string coursecode)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = villaUrl + "/" + coursecode
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = villaUrl
            });
        }

        public Task<T> GetAsync<T>(string coursecode)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = villaUrl + "/" + coursecode
            });
        }
        public Task<T> UpdateAsync<T>(CourseUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/" + dto.CourseCode
            });
        }
    }
}
