using USTIT.WEB.Areas.Auth.Models;

namespace USTIT.WEB.Areas.Auth.Services.IService
{
    public interface IAuthService
    {
        Task<T> RegisterAsync<T>(RegistrationRequestDto registrationRequestDto);
        Task<T> LoginAsync<T>(LoginRequestDto loginRequestDto);
        
    }
}
