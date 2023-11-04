using USTIT.WEB.Areas.Auth.Models;

namespace USTIT.WEB.Areas.Auth.Services.IService
{
    public interface IRoleService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetByRoleNameAsync<T>(string roleName);
        Task<T> GetAsync<T>(string id);
        Task<T> AssignRoleAsync<T>(AssignRoleDto assignRoleDto);
        Task<T> CreateRoleAsync<T>(CreateRoleDto createRoleDto);
        Task<T> RemoveRoleAsync<T>(string id);
        Task<T> RemoveByRoleNameAsync<T>(string roleName);
    }
}
