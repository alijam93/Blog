using Blog.Client.Utils.File;
using Blog.Shared.DTOs;
using Blog.Shared.Providers.Utils;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Utils.Models
{
    public class AddPostModel : AddPostDTO
    { 
        public string FileName { get; set; }

        [MaxFileSize(0.5 * 1024 * 1024)]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile Picture { get; set; }
    }

    public class EditPostModel : EditPostDTO
    { 
        public string FileName { get; set; }

        [MaxFileSize(0.5 * 1024 * 1024)]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile Picture { get; set; }
    }
}
