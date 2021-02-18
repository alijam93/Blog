using Blog.Shared.DTOs;
using Blog.Storage.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentsController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        /// <summary>
        /// Get comments by postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("{postId}")]
        public async Task<ActionResult<CommentDTO>> CommentsByPost(int postId)
        {
            var postComments = await _commentRepo.GetCommentsByPostId(postId);
            return Ok(postComments);
        }

        /// <summary>
        /// Get comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<CommentDTO>> Comment(int id)
        {
            var comment = await _commentRepo.GetCommentById(id); 
            return Ok(comment);
        }

        /// <summary>
        /// Add comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddCommentDTO>> AddComment(AddCommentDTO comment)
        {
            await _commentRepo.AddComment(comment);

            return Ok();
        }

        /// <summary>
        /// Add reply with parent comment id
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost("{parentId}")]
        public async Task<ActionResult<AddReplyDTO>> AddReply(int parentId, AddReplyDTO comment)
        {
            await _commentRepo.AddReply(comment, parentId);

            return Ok();
        }

        /// <summary>
        /// Edit comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<EditCommentDTO>> EditComment(int id, EditCommentDTO comment)
        {
            if (id != comment.Id) return BadRequest();

            try
            {
                await _commentRepo.UpdateComment(id, comment);
            }
            catch (DbUpdateConcurrencyException) when (!_commentRepo.CommentItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentRepo.DeleteComment(id);
            return NoContent();
        }
    }
}
