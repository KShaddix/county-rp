using Microsoft.EntityFrameworkCore;

namespace CountyRP.Forum.Domain.Models
{
    public class ForumContext : DbContext
    {
        public DbSet<ForumModel> Forums { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
