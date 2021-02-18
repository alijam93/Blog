using AutoMapper;
using AutoMapper.Configuration.Annotations;
using AutoMapper.Configuration.Conventions;
using Blog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
//using AutoMapper.Configuration.Annotations;
using System.Text;

namespace Blog.Shared.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        public int? ReplyId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Collection<ReplyDTO> Replies { get; set; }
    }

    public class ReplyDTO
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        public int ReplyId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
    public class AddCommentDTO
    {
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        [StringLength(25, ErrorMessage = "متن بسیار طولانی است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "متن خالی میباشد")]
        [StringLength(3000, ErrorMessage = "متن بسیار طولانی است")]
        public string Content { get; set; }
    }
    public class EditCommentDTO
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        [StringLength(25, ErrorMessage = "متن بسیار طولانی است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "متن خالی میباشد")]
        [StringLength(3000, ErrorMessage = "متن بسیار طولانی است")]
        public string Content { get; set; }
    } 
    public class AddReplyDTO
    { 
        public int? ReplyId { get; set; }
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        [StringLength(25, ErrorMessage = "متن بسیار طولانی است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "متن خالی میباشد")]
        [StringLength(3000, ErrorMessage = "متن بسیار طولانی است")]
        public string Content { get; set; }
    }
}
