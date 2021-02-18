using AutoMapper;
using Blog.Shared.DTOs;
using Blog.Shared.DTOs.Identity;
using Blog.Shared.Models;
using Blog.Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Storage
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserUpdateDTO>();
            CreateMap<Role, RoleDTO>();

            CreateMap<Post, PostDTO>().ReverseMap();
            //.ForMember(dst => dst.Tags, _ => _.MapFrom(src => src.PostTags.Select(_=>_.Tag).Select(_=> _.Name).ToList()));
            CreateMap<Post, AddPostDTO>().ReverseMap();
            CreateMap<Post, EditPostDTO>().ReverseMap();

            CreateMap<Comment, ReplyDTO>()
                 .ForMember(dst => dst.ReplyId, _ => _.MapFrom(src => src.ReplyId));
            CreateMap<Comment, CommentDTO>()
                .ForMember(dst => dst.Replies, _ => _.MapFrom(src => src.Replies));
            CreateMap<Comment, AddCommentDTO>().ReverseMap();
            CreateMap<Comment, EditCommentDTO>().ReverseMap();
            CreateMap<Comment, AddReplyDTO>().ReverseMap();

            CreateMap<Tag, TagDTO>();
            CreateMap<Tag, AddTagDTO>().ReverseMap();
            CreateMap<Tag, UpdateTagDTO>().ReverseMap();
        }
    }
}
