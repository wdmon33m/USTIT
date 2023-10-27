using USTIT.Services.AuthAPI.Models;
using USTIT.Services.AuthAPI.Models.Dto;

namespace USTIT.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<APIResponse> Register(RegistrationRequestDto registrationRequestDto);
        Task<APIResponse> Login(LoginRequestDto loginRequestDto);
        
    }
}
