﻿namespace USTIT.WEB.Areas.Auth.Models
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
