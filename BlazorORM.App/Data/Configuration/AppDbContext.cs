using BlazorORM.App.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorORM.App.Data.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Id);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Product { get; set; } = default!;
    }
}
