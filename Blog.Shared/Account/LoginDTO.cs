using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Shared.Account
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "ایمیل نباید خالی باشد")]
        public string EmailOrName { get; set; } 

        [Required(ErrorMessage = "پسورد نباید خالی باشد")]
        public string Password { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public bool RememberMe { get; set; }
    }
}
