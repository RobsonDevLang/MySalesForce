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
                .HasMaxLength(500);

            builder.Property(p => p.Weight)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Height)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Width)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Observation)
                .HasMaxLength(500);

            builder.Property(p => p.ShortName)
                .HasMaxLength(100);
        }
        
    }
}