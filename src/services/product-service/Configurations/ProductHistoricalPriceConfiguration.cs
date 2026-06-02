using HistoricalPrice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Configurations
{
    public class ProductHistoricalPriceConfiguration : IEntityTypeConfiguration<ProductHistoricalPriceModel>
    {
        public void Configure(EntityTypeBuilder<ProductHistoricalPriceModel> builder)
        {

        }
        
    }
}