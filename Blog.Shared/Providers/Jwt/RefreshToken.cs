using System;

namespace Blog.Shared.Providers.Jwt
{
    public class RefreshToken
    {
        public string UserName { get; set; }    // can be used for usage tracking
        // can optionally include other metadata, such as user agent, ip address, device name, and so on

        public string TokenString { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}