
using ProductImage.Models;
using HistoricalPrice.Models;
using Size.Models;

namespace Product.Models
{
    public class ProductModel
    {
        public int Id { get; set;}
        public string Code {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
        public string Description { get; set;} = string.Empty;
        public int Status {get; set;} = 1;
        public decimal Weight {get; set;}
        public decimal Height {get; set;}
        public decimal Width { get; set;}
        public string? Observation {get; set;}
        public string? ShortName {get; set;}

// Foreing Keys
        public int ConditionalId {get; set;}
        public int CategoryId { get; set;}
        public int BrandId {get; set;}

// Navigation Properties
        public BrandModel Brand { get; set; } = null!;
        public CategoryModel Category { get; set; } = null!;

// Relationships
        public List<ProductSizeModel> ProductSizes { get; set; } = new();
        public List<ProductImageModel> ProductImages {get; set;} = new();
        public List<ProductHistoricalPriceModel> ProductHistoricalPrices {get; set;} = new();

    }
}