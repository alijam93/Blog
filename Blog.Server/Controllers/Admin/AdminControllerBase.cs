using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Blog.Server.Controllers.Admin
{
    //[Authorize(Policy = Policies.IsAdmin)]
    [ApiController]
    public class AdminControllerBase : ControllerBase
    {
    }
}
