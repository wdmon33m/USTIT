using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using USTIT.WEB.Areas.Auth.Models;
using USTIT.WEB.Areas.Auth.Services.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using USTIT.WEB.Models;

namespace USTIT.WEB.Areas.Auth.Controllers
{
    [Area("Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, IRoleService roleService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _roleService = roleService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            APIResponse responseDto = await _authService.LoginAsync<APIResponse>(obj);
            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto? loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));
                await SignInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);
                return RedirectToAction("Index","Home", new { area = "Customer" });
            }
            
            TempData["error"] = responseDto.ErrorMessages.First();
            return View(obj);
        }
        public async Task SignInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                                        jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                                        jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                                        jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                                        jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email).Value));

             identity.AddClaim(new Claim(ClaimTypes.Role,
                                        jwt.Claims.FirstOrDefault(c => c.Type == "role").Value));

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            try
            {
                obj.FullStdId = obj.FullStdId.ToUpper();
                var result = await _authService.RegisterAsync<APIResponse>(obj);
                if (result != null && result.IsSuccess)
                {
                    TempData["success"] = "User created successfully";
                    return RedirectToAction(nameof(Login));
                }
                else 
                {
                    TempData["error"] = result.ErrorMessages.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View(obj);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home", new { area = "Customer" });
        }
    }
}
