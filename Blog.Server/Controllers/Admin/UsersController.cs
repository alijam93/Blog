﻿using Blog.Shared.DTOs.Identity;
using Blog.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Server.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    public class UsersController : AdminControllerBase
    {
        private readonly UserManager<User> _userManager;


        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> ListUsers()
        {
            var users = await _userManager.Users.Select(u => new UserDTO
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                UserRoles = u.UserRoles.Select(_=> _.Role.Name).ToList() 
            }).AsNoTracking().ToListAsync();

            return Ok(users);
        }


        [HttpPut]
        public async Task<ActionResult> EditUser(UserUpdateDTO userModel)
        {
            var user = await _userManager.FindByIdAsync(userModel.Id);
            if (user == null) return NotFound("User not found.");
            var currentRole = await _userManager.GetRolesAsync(user);

            //bool isAdminUser = await _userManager.IsInRoleAsync(user, Policies.IsAdmin);
            //if (!isAdminUser)
            //{ 
            await _userManager.RemoveFromRolesAsync(user, currentRole);
            await _userManager.AddToRoleAsync(user, userModel.RoleName);

            user.UserName = userModel.UserName;
            user.Email = userModel.Email;


            await _userManager.UpdateAsync(user);

            return Ok();
        }
    }
}








