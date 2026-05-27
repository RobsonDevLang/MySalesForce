using Microsoft.EntityFrameworkCore;
using Product.Configurations;
using Product.Models;
using Product.Services;

namespace Product.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<ProductModel> Products  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}