using System;
using System.Collections.Generic;

namespace entity
{
    public class Post
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string content { get; set; }
        public int viewCount { get; set; }
        public int headerId { get; set; }
        public Header header { get; set; }
        public List<PostCategory> postcategory { get; set; }
        public List<Comment> Comments { get; set; }
    }
}