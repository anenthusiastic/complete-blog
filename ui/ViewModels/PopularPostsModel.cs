using System.Collections.Generic;
using entity;

namespace ui.ViewModels
{
    public class PopularPostsModel
    {
        public List<int> postids { get; set; }
        public List<Header> popularposts { get; set; }
        public List<string> daydifference { get; set; }
    }
}