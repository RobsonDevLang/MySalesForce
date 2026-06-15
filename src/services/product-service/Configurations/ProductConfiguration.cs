using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Models;

namespace Product.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasIndex(p => p.Code)
                .IsUnique();

            builder.Property(p => p.Name)
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .HasColumnType("text");

            builder.Property(p => p.Weight)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Height)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Width)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Observation)
                .HasColumnType("text");

            builder.Property(p => p.ShortName)
                .HasMaxLength(100);

            // Configurações adicionais, como relacionamentos, chaves estrangeiras, etc.  
           builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

           builder.HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId);
                
        }
        
    }
}