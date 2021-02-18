using Blog.Client.Shared;
using Blog.Shared.DTOs;
using Blog.Shared.Extensions;
using Blog.Shared.Providers.File;
using Blog.Shared.Providers.Pagination;
using Blog.Storage.Repositories.Interfaces;
using Blog.Storage.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Blog.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepo;

        public PostsController(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        /// <summary>
        ///  Get all posts
        /// </summary>
        /// <param name="postParameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PostDTO>> Posts([FromQuery] PostParameters postParameters)
        {
            //ActionResult<PostDTO>
            var posts = await _postRepo.GetPosts(postParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(posts.Paging));
            return Ok(posts);
        }

        /// <summary>
        /// Get posts by their tag
        /// </summary>
        /// <param name="postParameters"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<PostDTO>> PostsByTag([FromQuery] PostParameters postParameters,
                                                                                string name)
        {
            var posts = await _postRepo.GetPostsByTag(postParameters, name);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(posts.Paging));
            return Ok(posts);

        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        //[HttpGet("{id}")]
        [HttpGet("{id}/{slug}")]
        public async Task<ActionResult<PostDTO>> Post(int id, string slug)
        {
            var post = await _postRepo.GetPostById(id);
            // Get the actual friendly version of the title.
            //string friendlyTitle = FriendlyUrlExtension.GetSlugTitle(post.Title);
            var friendlyUrl = FriendlyUrlExtension.GetSlugTitle(post.Title);
            if (slug != friendlyUrl) throw new InvalidOperationException($"Slug format not matched. slug={slug}");

            //slug= friendlyTitle;
            return Ok(post);
        }

        /// <summary>
        /// Add post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddPostDTO>> AddPost(AddPostDTO post)
        {
            await _postRepo.AddPost(post);
            return Ok();
        }

        /// <summary>
        /// Edit post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        //[Authorize(Policy = Policies.IsAdmin)]
        public async Task<ActionResult<EditPostDTO>> EditPost(int id, EditPostDTO post)
        {
            if (id != post.Id) return BadRequest();

            try
            {
                await _postRepo.UpdatePost(post);
            }
            catch (DbUpdateConcurrencyException) when (!_postRepo.PostItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = Policies.IsAdmin)]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postRepo.DeletePost(id);
            return NoContent();
        }
    
        /// <summary>
        /// Upload from data image for a post.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost("AddImage")]
        [Consumes("multipart/form-data")]
        public ActionResult<string> AddImage([FromForm] UploadModel image)
        {
            var result = _postRepo.SendImage(image);

            return Ok(result);
        }
    }
}
