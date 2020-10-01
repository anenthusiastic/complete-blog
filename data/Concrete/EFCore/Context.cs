using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete.EFCore
{
    public class Context:DbContext
    {
        public DbSet<Post> Posts {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Message> Messages {get; set;}
        public DbSet<Header> Headers {get; set;}
        public DbSet<Comment> Comments {get; set;}
        public DbSet<LoginInfo> LoginInfos {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source=blogDb");
        }
        protected override void OnModelCreating(ModelBuilder mb){
            mb.Entity<PostCategory>().HasKey(c=> new {c.categoryId,c.postId});
            mb.Entity<Post>()
                .HasOne(p => p.header)
                .WithOne(h => h.post);
            } 
        }
}