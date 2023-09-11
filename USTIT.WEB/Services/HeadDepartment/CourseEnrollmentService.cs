using USTIT.WEB.Areas.HeadDepartment.Models;
using USTIT.WEB.Models;
using USTIT.WEB.Services.IServices.BasicData;
using USTIT.WEB.Utility;

namespace USTIT.WEB.Services.HeadDepartment
{
    public class CourseEnrollmentService : BaseService, ICourseEnrollmentService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CourseEnrollmentService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            apiUrl = configuration.GetValue<string>("ServiceUrls:HeadDepartmentAPI") + "/api/" + apiVersion + "/courseEnrollment";
        }

        private string apiUrl;
        private const string apiVersion = "v1";
        public Task<T> CreateAsync<T>(CourseEnrollmentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync<T>(string coursecode)
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

        public Task<T> GetAsync<T>(string ceNo)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync<T>(CourseEnrollmentDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
