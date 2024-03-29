﻿using Blog.Shared.Providers.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Providers.File
{
    public class UploadModel
    {
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(0.5 * 1024 * 1024)]
        [AllowedFileExtensions(new[] { ".jpg", ".png" })]
        public IFormFile Image { get; set; }
    }
}
