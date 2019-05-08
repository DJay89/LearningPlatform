using LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.Data
{
    public class ResearchContext : DbContext
    {
        public ResearchContext(DbContextOptions<ResearchContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<AppData> AppData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<AppData>().ToTable("AppData");
        }
    }
}
