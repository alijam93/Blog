using Blog.Shared.Extensions;
using Blog.Shared.Providers.File;
using Blog.Storage.Repositories.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Storage.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        public string AddAvatar(UploadModel file)
        {
            string extension = Path.GetExtension(file.Image.FileName);
            string newFileName = $"{Guid.NewGuid()}{extension}";

            var folderName = Path.Combine("wwwroot", "images/profile", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            string dbPath = Path.Combine(folderName, newFileName);

            if (file.Image.Length > 0)
            {

                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), folderName, newFileName);
                using var image = Image.Load(file.Image.OpenReadStream());
                image.Mutate(x => x.Resize(150, 150));
                //Encode here for quality
                var encoder = new JpegEncoder()
                {
                    Quality = 30 //Use variable to set between 5-30 based on your requirements
                };

                image.Save(fullPath, encoder);
            }
            return dbPath;
        }

        public string AddImagePost(UploadModel file)
        {
            string title = FriendlyUrlExtension.GetSlugTitle(file.Name);
            string extension = Path.GetExtension(file.Image.FileName);
            string newFileName = $"{title}{extension}";

            var folderName = Path.Combine("wwwroot", "images/posts", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"));
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            string dbPath = Path.Combine(folderName, newFileName);

            if (file.Image.Length > 0)
            {

                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), folderName, newFileName);
                using var image = Image.Load(file.Image.OpenReadStream());
                image.Mutate(x => x.Resize(300, 200));
                //Encode here for quality
                var encoder = new JpegEncoder()
                {
                    Quality = 30 //Use variable to set between 5-30 based on your requirements
                };

                image.Save(fullPath, encoder);
            }
            return dbPath;
        }
    }
}
