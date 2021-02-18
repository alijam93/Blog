using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.Account
{
    public class RefreshTokenDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
