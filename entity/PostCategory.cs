namespace entity
{
    public class PostCategory
    {
        public int postId { get; set; }
        public Post post { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}