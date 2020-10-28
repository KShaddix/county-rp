using Microsoft.EntityFrameworkCore;

namespace CountyRP.Forum.Domain.Models
{
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public PostContext(DbContextOptions<PostContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
