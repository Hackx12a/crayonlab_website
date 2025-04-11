using Microsoft.EntityFrameworkCore;
using Crayonlab.Models;

namespace Crayonlab.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // New simplified structure
        public DbSet<ShirtType> ShirtTypes { get; set; }
        public DbSet<ShirtDesign> ShirtDesigns { get; set; }

        // Keep these if you still need them for existing functionality
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Partners> Partners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between ShirtType and ShirtDesign
            modelBuilder.Entity<ShirtDesign>()
                .HasOne(sd => sd.ShirtType)
                .WithMany(st => st.ShirtDesigns)
                .HasForeignKey(sd => sd.ShirtTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade if appropriate

            // Seed initial shirt types if needed
            modelBuilder.Entity<ShirtType>().HasData(
                new ShirtType { Id = 1, Name = "Corporate", Description = "Corporate shirts collection" },
                new ShirtType { Id = 2, Name = "Basketball", Description = "Basketball jerseys collection" },
                new ShirtType { Id = 3, Name = "Soccer", Description = "Soccer jerseys collection" },
                new ShirtType { Id = 4, Name = "LongSleeve", Description = "Long sleeve shirts collection" }
            );
        }
    }
}