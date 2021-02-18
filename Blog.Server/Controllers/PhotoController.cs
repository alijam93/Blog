using Blog.Shared.Providers.File;
using Blog.Storage.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepo;

        public PhotoController(IPhotoRepository photoRepo)
        {
            _photoRepo = photoRepo;
        }

        /// <summary>
        /// Upload from user profile for a post.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost("addAvatar")]
        public ActionResult<string> SendAvatar([FromForm] UploadModel image)
        {
            var result = _photoRepo.AddAvatar(image);

            return Ok(result);
        }

        /// <summary>
        /// Upload from data image for a post.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost("addImage")]
        public ActionResult<string> SendImage([FromForm] UploadModel image)
        {
            var result = _photoRepo.AddImagePost(image);

            return Ok(result);
        }

        /// <summary>
        /// Delete the specified image.
        /// </summary>
        /// <param name="file"></param>
        [HttpPost("deleteFile")]
        public void Delete([FromBody] DeleteFile file)
        {
                var path = Path.Combine(Directory.GetCurrentDirectory(), file.Path);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                else
                {
                    BadRequest();
                }
        }
    }
}
