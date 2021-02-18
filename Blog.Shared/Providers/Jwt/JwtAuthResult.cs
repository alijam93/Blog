using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.Providers.Jwt
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}
