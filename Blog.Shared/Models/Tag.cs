
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Shared.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
