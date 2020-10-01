using System.Collections.Generic;
using entity;

namespace ui.ViewModels
{
    public class PostViewModel
    {
        public Post post { get; set; }
        public List<string> categoryNames { get; set; }
        public Header postHeader { get; set; }
        public List<Comment> comments { get; set; }
    }
}