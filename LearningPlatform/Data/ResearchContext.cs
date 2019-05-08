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
        public DbSet<Models.Data> Data { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Data)
                .WithOne(ad => ad.User)
                .IsRequired();
        }
    }
}
