using Microsoft.AspNetCore.Identity;

namespace USTIT.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullStdId { get; set; }
    }
}
