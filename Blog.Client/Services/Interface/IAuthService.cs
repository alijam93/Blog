using Blog.Shared.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Services.Interface
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginDTO loginModel);
        Task<RegisterResult> Register(RegisterDTO registerModel);
        Task Logout();
        Task<string> RefreshToken();
    }
}
