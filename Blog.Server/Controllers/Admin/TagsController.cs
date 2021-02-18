using Blog.Shared.DTOs;
using Blog.Storage.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace Blog.Server.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    public class TagsController : AdminControllerBase
    {
        private readonly ITagRepository _tagRepo;

        public TagsController(ITagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        /// <summary>
        /// Get all tags
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TagDTO>> Tags()
        {
            return await _tagRepo.GetTags();
        }

        /// <summary>
        /// Get Tags which not selected in post
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        [HttpGet("{tagId}")]
        public async Task<ActionResult<IEnumerable<TagDTO>>> UnselectedTags(int tagId)
        {
            var tags = await _tagRepo.GetUnselectedTags(tagId);
            return Ok(tags);

        }

        /// <summary>
        /// Add tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddTagDTO>> AddTag(AddTagDTO tag)
        {
            await _tagRepo.AddTag(tag);
            return Ok();
        }

        /// <summary>
        /// Update tag
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateTagDTO>> UpdateTag(int id, UpdateTagDTO tag)
        {
            if (id != tag.Id) return BadRequest();


            await _tagRepo.UpdateTag(tag);
            return NoContent();
        }
    }
}
