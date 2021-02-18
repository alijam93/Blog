using Blog.Shared.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Services.Interface
{
    public interface IProfileService
    {
        Task<UserInfoDTO> UserProfile();
        Task<string> UserRole();
    }
}
