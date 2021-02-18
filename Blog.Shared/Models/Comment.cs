using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace Blog.Shared.Models
{
    public class Comment
    { 
        [Key]
        public int Id { get; set; }
        public int? ReplyId { get; set; }
        public int? PostId { get; set; } 
        public int? CourseId { get; set; } 
        public int UserId { get; set; }

        [StringLength(25, ErrorMessage = "متن بسیار طولانی است")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "متن خالی میباشد")]
        [StringLength(3000, ErrorMessage = "متن بسیار طولانی است")]
        public string Content { get; set; }

        //public IPAddress IpAddress { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }

        #region navigation 
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public Course Course { get; set; }

        [ForeignKey("ReplyId")]
        public Comment ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; }
        #endregion
    }
}