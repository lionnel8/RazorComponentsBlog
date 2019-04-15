using Microsoft.EntityFrameworkCore;
using RazorComponentsBlog.Models;

namespace RazorComponentsBlog.Data
{
    public class RazorComponentsBlogDbContext : DbContext
    {
        public RazorComponentsBlogDbContext(DbContextOptions<RazorComponentsBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}