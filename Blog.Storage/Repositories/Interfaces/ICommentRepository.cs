using Blog.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Storage.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<CommentDTO>> GetCommentsByPostId(int postId);
        Task<CommentDTO> GetCommentById(int id);
        Task AddComment(AddCommentDTO postDTO);
        Task AddReply(AddReplyDTO replyDTO, int parentId);
        //Task UpdateComment(EditCommentDTO commentDTO);
        Task UpdateComment(int id, EditCommentDTO commentDTO);
        Task DeleteComment(int id);
        bool CommentItemExists(int id);
    }
}
