using Blog.Shared.DTOs.Identity;
using Blog.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public ProfileController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("getUserById/{id}")]
        public async Task<ActionResult<UserInfoDTO>> UserById(string id)
        { 

            var userId = await _userManager.Users.FirstOrDefaultAsync(_ => _.Id == new Guid(id));
            var rolename = await _userManager.GetRolesAsync(userId);

            var user = new UserInfoDTO
            {
                UserName = userId.UserName,
                Email = userId.Email,
                Avatar = userId.Avatar,
                Role = rolename.FirstOrDefault()
            };

            return Ok(user);
             
            //if (User.Identity.IsAuthenticated)
            //{
            //}
            //else
            //{
            //    return NotFound();
            //}
        }

        [HttpGet("getUserRoleById/{id}")]
        public async Task<ActionResult<string>> UserRoleById(string id)
        {
            var userId = await _userManager.Users.FirstOrDefaultAsync(_ => _.Id == new Guid(id));
            var rolename = await _userManager.GetRolesAsync(userId);

            return Ok(rolename.FirstOrDefault());
        }
    }
}
