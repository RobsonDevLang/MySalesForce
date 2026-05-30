using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Models;

namespace Product.Configurations
{
    // Tabela de junção para N:N entre ProductModel e SizeModel
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSizeModel>
    {
        public void Configure(EntityTypeBuilder<ProductSizeModel> builder)
        {
            builder.ToTable("product_size");

            builder.HasKey(x => new { x.ProductId, x.SizeId });

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductSizes)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Size)
                .WithMany()
                .HasForeignKey(x => x.SizeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.ProductId).HasColumnName("product_id");
            builder.Property(x => x.SizeId).HasColumnName("size_id");
        }
    }
}

