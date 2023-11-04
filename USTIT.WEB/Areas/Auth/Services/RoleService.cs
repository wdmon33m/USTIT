using USTIT.WEB.Areas.Auth.Services.IService;
using USTIT.WEB.Areas.Auth.Models;
using USTIT.WEB.Models;
using USTIT.WEB.Services;
using USTIT.WEB.Utility;

namespace USTIT.WEB.Areas.Auth.Services
{
    public class RoleService : BaseService, IRoleService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apiUrl;
        private const string apiVersion = "v1";

        public RoleService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            apiUrl = configuration.GetValue<string>("ServiceUrls:AuthAPI") + "/api/" + apiVersion + "/role/";
        }

        public async Task<T> AssignRoleAsync<T>(AssignRoleDto assignRoleDto)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = assignRoleDto,
                Url = apiUrl + "assign"
            });
        }

        public async Task<T> CreateRoleAsync<T>(CreateRoleDto createRoleDto)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = createRoleDto,
                Url = apiUrl
            });
        }
        public async Task<T> RemoveRoleAsync<T>(RemoveRoleDto removeRoleDto)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = removeRoleDto,
                Url = apiUrl
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl
            });
        }

        public async Task<T> GetByRoleNameAsync<T>(string roleName)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl + "GetByName/" + roleName
            });
        }

        public async Task<T> GetAsync<T>(string id)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl + id
            });
        }

        public async Task<T> RemoveRoleAsync<T>(string id)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = apiUrl + id
            });
        }

        public async Task<T> RemoveByRoleNameAsync<T>(string roleName)
        {
            return await SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = apiUrl + "romovebyname/" + roleName
            });
        }
    }
}
