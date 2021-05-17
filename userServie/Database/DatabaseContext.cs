using System;
using Microsoft.EntityFrameworkCore;
using userService.Database.Entities;

namespace userService.Database
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql("WebjetDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.Name).IsRequired(false);
            modelBuilder.Entity<User>().Property(e => e.Address).IsRequired(false);
            modelBuilder.Entity<User>().Property(e => e.contact).IsRequired(false);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
