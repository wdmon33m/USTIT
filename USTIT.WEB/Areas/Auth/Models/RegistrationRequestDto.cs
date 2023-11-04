namespace USTIT.WEB.Areas.Auth.Models
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; }
        public string? FullStdId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
