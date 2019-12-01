using Microsoft.EntityFrameworkCore;
using georgecarlinwebsite.Models;

namespace georgecarlinwebsite.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Story> Stories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
