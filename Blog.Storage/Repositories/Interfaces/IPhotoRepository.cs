using Blog.Shared.Providers.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Storage.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        string AddImagePost(UploadModel file);
        string AddAvatar(UploadModel file);
    }
}
