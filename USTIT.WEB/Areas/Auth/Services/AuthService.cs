using USTIT.WEB.Areas.Auth.Models;
using USTIT.WEB.Areas.Auth.Services.IService;
using USTIT.WEB.Models;
using USTIT.WEB.Services;
using USTIT.WEB.Utility;

namespace USTIT.WEB.Areas.Auth.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apiUrl;
        private const string apiVersion = "v1";

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            apiUrl = configuration.GetValue<string>("ServiceUrls:AuthAPI") + "/api/" + apiVersion + "/auth/";
        }

        public async Task<T> LoginAsync<T>(LoginRequestDto loginAPIResponse)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = loginAPIResponse,
                Url = apiUrl + "login",
                WithBearer = false
            });
        }

        public async Task<T> RegisterAsync<T>(RegistrationRequestDto registrationAPIResponse)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationAPIResponse,
                Url = apiUrl + "register",
                WithBearer = false
            });
        }
    }
}
