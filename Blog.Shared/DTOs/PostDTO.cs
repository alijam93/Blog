
using Blog.Shared.Models;
using Blog.Shared.Providers.File;
using Blog.Shared.Providers.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace Blog.Shared.DTOs
{ 
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int Like { get; set; }
        public int Visitor { get; set; }
        public DateTime Created { get; set; } 
        public IEnumerable<TagDTO> Tags { get; set; } = new HashSet<TagDTO>(); 
    }

    public class AddPostDTO
    {
        [Required(ErrorMessage = "عنوان خالی میباشد")]
        [MinLength(25, ErrorMessage = "عنوان بسیار کوتاه است")]
        [MaxLength(80, ErrorMessage = "عنوان بسیار طولانی است")]
        public string Title { get; set; }

        [Required(ErrorMessage = "متن خالی میباشد")]
        [MinLength(1000, ErrorMessage = "متن بسیار کوتاه است")]
        [MaxLength(10000, ErrorMessage = "متن بسیار طولانی است")]
        public string Content { get; set; }

        /// <summary>
        /// Response image path
        /// </summary>
        public string Image { get; set;  }

        [Required(ErrorMessage = "تگ خالی میباشد")]
        public string AddTags { get; set; } 
    }


    public class EditPostDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان خالی میباشد")]
        [MinLength(25, ErrorMessage = "عنوان بسیار کوتاه است")]
        [MaxLength(80, ErrorMessage = "عنوان بسیار طولانی است")]
        public string Title { get; set; }

        [Required(ErrorMessage = "متن خالی میباشد")]
        [MinLength(1000, ErrorMessage = "متن بسیار کوتاه  است")]
        [MaxLength(10000, ErrorMessage = "متن بسیار طولانی است")]
        public string Content { get; set; }

        /// <summary>
        /// Response image path
        /// </summary>
        public string Image { get; set; }

        public IEnumerable<int> AddTags { get; set; } = new List<int>();
        public IEnumerable<int> RemoveTags { get; set; } = new List<int>();
    }
}
