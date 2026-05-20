using Microsoft.EntityFrameworkCore;
using MoodTracker.Models;

namespace MoodTracker.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MoodEntry> MoodEntries => Set<MoodEntry>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoodEntry>(e =>
            {
                e.Property(x => x.Mood)
                 .HasConversion<string>()  
                 .HasMaxLength(20);

                e.Property(x => x.Note)
                 .HasMaxLength(280);

                e.Property(x => x.Timestamp)
                 .IsRequired();

                e.HasIndex(x => x.Timestamp);
            });
        }
    }
}
