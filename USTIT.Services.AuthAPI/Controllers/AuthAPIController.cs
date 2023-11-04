using Microsoft.AspNetCore.Mvc;
using USTIT.Services.AuthAPI.Models;
using USTIT.Services.AuthAPI.Models.Dto;
using USTIT.Services.AuthAPI.Service.IService;
using USTIT.Services.AuthAPI.Utility;

namespace USTIT.Services.AuthAPI.Controllers
{
    [Route("api/v{version:apiVersion}/auth")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;

        public AuthAPIController(IAuthService authService, IRoleService roleService)
        {
            _authService = authService;
            _roleService = roleService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Register([FromBody] RegistrationRequestDto model)
        {
            var response = await _authService.Register(model);

            if (response.IsSuccess)
            {
                AssignRoleDto assignRoleDto = new() { Email = model.Email, RoleName = SD.RoleCustomer };

                var _roleResponse = await _roleService.AssignRole(assignRoleDto);

                if (!_roleResponse.IsSuccess)
                {
                    return _roleResponse;
                }
            }

            return response;
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Login([FromBody] LoginRequestDto model)
        {
            return await _authService.Login(model);
        }
    }
}
