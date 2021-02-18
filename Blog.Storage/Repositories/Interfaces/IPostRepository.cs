using Blog.Shared.DTOs;
using Blog.Shared.Models;
using Blog.Shared.Providers.File;
using Blog.Shared.Providers.Pagination;
using Blog.Storage.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Storage.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<PagedList<PostDTO>> GetPosts(PostParameters postParameters);
        Task<PagedList<PostDTO>> GetPostsByTag(PostParameters postParameters, string name);
        Task<PostDTO> GetPostById(int id);
        Task AddPost(AddPostDTO postDTO);
        Task UpdatePost(EditPostDTO postDTO);
        Task DeletePost(int id);
        string SendImage(UploadModel image);    
        bool PostItemExists(int id);
    }
}
