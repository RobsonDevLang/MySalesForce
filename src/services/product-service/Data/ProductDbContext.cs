using HistoricalPrice.Models;
using Microsoft.EntityFrameworkCore;
using Product.Configurations;
using Product.Models;
using ProductImage.Models;
using Size.Models;

namespace Product.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<SizeModel> Size { get; set; }
        public DbSet<ProductSizeModel> ProductSize { get; set; }
        public DbSet<ProductHistoricalPriceModel> HistoricalPrice { get; set; }
        public DbSet<ProductImageModel> ProductImage { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

