using Blog.Client.Shared;
using Blog.Client.Utils.File;
using Blog.Shared.Account;
using Blog.Shared.Providers.Utils;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Utils.Models
{ 
        public class RegisterModel : RegisterDTO
        {
            public string FileName { get; set; }

            public string File { get; set; }

            [ClientMaxFileSizeAttribute(0.5 * 1024 * 1024)]
            [FileValidation(new[] { ".png", ".jpg" })]
            public IBrowserFile Picture { get; set; }
        } 
}
