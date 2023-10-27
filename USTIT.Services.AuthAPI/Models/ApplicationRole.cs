using Microsoft.AspNetCore.Identity;

namespace USTIT.Services.AuthAPI.Models
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsActive { get; set; } = true;
    }
}
