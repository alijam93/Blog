using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.DTOs.Identity
{
    public class GroupedUserDTO
    {
        public List<UserDTO> Users { get; set; }
        public List<UserDTO> Admins { get; set; }
    }
}
