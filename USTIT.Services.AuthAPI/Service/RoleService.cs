using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using USTIT.Services.AuthAPI.Models;
using USTIT.Services.AuthAPI.Models.Dto;
using USTIT.Services.AuthAPI.Service.IService;
using USTIT.Services.AuthAPI.Utility;

namespace USTIT.Services.AuthAPI.Service
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public RoleService(RoleManager<ApplicationRole> roleManager, 
            UserManager<ApplicationUser> userManager, 
            IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _response = new();
            _mapper = mapper;
        }

        public async Task<APIResponse> AssignRole(AssignRoleDto assignRoleDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(assignRoleDto.Email.ToLower());
                if (user == null)
                {
                    return _response.BadRequest("User is not exist!");
                }

                var isRollExist = _roleManager.RoleExistsAsync(assignRoleDto.RoleName).GetAwaiter().GetResult();

                if (!isRollExist)
                {
                    return _response.BadRequest( "Role " + assignRoleDto.RoleName + " is not exist");
                }

                var result = await _userManager.AddToRoleAsync(user, assignRoleDto.RoleName);
                if (!result.Succeeded)
                {
                    return _response.BadRequest(result.Errors.First().Description);
                }

                _response.Result = "Role : " + assignRoleDto.RoleName + " added to " + assignRoleDto.Email + " Successufully";
                _response.StatusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }

        public async Task<APIResponse> CreateRole(CreateRoleDto createRoleDto)
        {
            try
            {
                ApplicationRole role = _mapper.Map<ApplicationRole>(createRoleDto);

                var result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    return _response.BadRequest(result.Errors.First().Description);
                }

                RoleDto roleDto = _mapper.Map<RoleDto>(role);

                _response.Result = roleDto;
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }

        public async Task<APIResponse> RemoveRoleAsync(string filter, bool isRemoveById = true)
        {
            try
            {
                ApplicationRole role = new();
                
                if (isRemoveById)
                {
                    role = await _roleManager.FindByIdAsync(filter);
                }
                else
                {
                    role = await _roleManager.FindByNameAsync(filter.ToLower());
                }

                if (role == null)
                {
                    return _response.BadRequest("Role " + filter + " is not exist!");
                }

                if (role.Name.Equals(SD.RoleAdmin) || role.Name.Equals(SD.RoleCustomer))
                {
                    _response.ErrorMessages = new() { "You can not remove this role" };
                    return _response;
                }

                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    return _response.BadRequest(result.Errors.First().Description);
                }

                _response.Result = "Role has been removed successfully";
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
       }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                _response.Result = await _roleManager.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }

        public async Task<APIResponse> GetByRoleNameAsync(string roleName)
        {
            try
            {
                var result = await _roleManager.FindByNameAsync(roleName);
                if (result is null)
                {
                    return _response.BadRequest("Role " + roleName + " is not exist!");
                }

                _response.Result = result;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }

        public async Task<APIResponse> GetByIdAsync(string id)
        {
            try
            {
                var result = await _roleManager.FindByIdAsync(id);
                if (result is null)
                {
                    return _response.BadRequest("Role " + id + " is not exist!");
                }

                _response.Result = result;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.InternalServerError(ex.Message);
            }
            return _response;
        }
    }
}
