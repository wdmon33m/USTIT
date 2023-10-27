using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Net;
using USTIT.Services.AuthAPI.Models;
using USTIT.Services.AuthAPI.Models.Dto;
using USTIT.Services.AuthAPI.Service.IService;

namespace USTIT.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public AuthService(UserManager<ApplicationUser> userManager, 
            IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _response = new();
            _mapper = mapper;
        }
        public async Task<APIResponse> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginRequestDto.UserName.ToLower());

                if (user == null)
                {
                    return _response.BadRequest("Username or password is incorrect");
                }

                bool isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (!isPasswordValid)
                {
                    return _response.BadRequest("Username or password is incorrect");
                }

                //if user was found and password was correct, Generate GWT Token

                var roles = await _userManager.GetRolesAsync(user);
                var token = _jwtTokenGenerator.GenerateToken(user, roles);

                UserDto userDto = _mapper.Map<UserDto>(user);

                LoginResponseDto loginResponseDto = new LoginResponseDto()
                {
                    User = userDto,
                    Token = token
                };

                _response.Result = loginResponseDto;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }

        public async Task<APIResponse> Register(RegistrationRequestDto registrationRequestDto)
        {
            try
            {
                ApplicationUser user = _mapper.Map<ApplicationUser>(registrationRequestDto);

                user.UserName = registrationRequestDto.Email;
                user.NormalizedEmail = registrationRequestDto.Email.ToUpper();

                var result = await _userManager.CreateAsync(user,registrationRequestDto.Password);
                if (!result.Succeeded)
                {
                    return _response.BadRequest(result.Errors.First().Description);
                }

                UserDto userDto = _mapper.Map<UserDto>(user);

                _response.Result = userDto;
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }
    }
}
