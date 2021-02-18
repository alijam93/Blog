using Blog.Client.Shared;
using Blog.Shared.Providers.Utils;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Utils.File
{
    public class BrowserFileModel
    {
        public string FileName { get; set; }

        [Required(ErrorMessage = "تصویر خالی میباشد")]
        [MaxFileSize(0.5 * 1024 * 1024)]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile Picture { get; set; }
    }
}
