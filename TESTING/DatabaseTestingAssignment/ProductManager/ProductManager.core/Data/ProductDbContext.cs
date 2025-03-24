using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Models;
namespace ProductManagement.Data.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasIndex(c => c.Name)
            .IsUnique();
        }
    }
}