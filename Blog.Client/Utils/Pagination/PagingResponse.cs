using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Shared.Providers.Pagination;

namespace Blog.Client.Utils.Pagination
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public Paging Paging { get; set; }
    }
}
