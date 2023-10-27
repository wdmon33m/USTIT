using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using USTIT.Services.AuthAPI.Models;
using USTIT.Services.AuthAPI.Models.Dto;
using USTIT.Services.AuthAPI.Service.IService;
using System.Net;

namespace USTIT.Services.AuthAPI.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleAPIController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleAPIController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Get()
        {
            return await _roleService.GetAllAsync();
        }

        [HttpGet("GetByName/{roleName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetByName(string roleName)
        {
            return await _roleService.GetByRoleNameAsync(roleName);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetById(string id)
        {
            return await _roleService.GetByIdAsync(id);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateRole([FromBody] CreateRoleDto model)
        {
            return await _roleService.CreateRole(model);
        }
        [HttpPost("assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> AssignRole([FromBody] AssignRoleDto model)
        {

            return await _roleService.AssignRole(model);
        }

        [HttpDelete("romovebyname/{roleName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> RemoveRoleByName(string roleName)
        {
            return await _roleService.RemoveRoleAsync(roleName,false);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> RemoveRoleByID(string id)
        {
            return await _roleService.RemoveRoleAsync(id);
        }
    }
}
