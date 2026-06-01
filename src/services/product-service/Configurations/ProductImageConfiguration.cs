using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Models;
using ProductImage.Models;

namespace Product.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImageModel>
    {
        public void Configure(EntityTypeBuilder<ProductImageModel> builder)
        {
            builder.Property(p => p.Url)
                .HasColumnType("text");

            builder.Property(p => p.AltText)
                .HasColumnType("text");

            builder.Property(p => p.MainImage)
                .HasColumnType("boolean");

            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(p => p.ProductId);
        }
        
    }
}