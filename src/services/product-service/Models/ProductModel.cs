
// using Product.Validators;
using ProductImage.Models;
using HistoricalPrice.Models;
// using Mark.Models;
// using Category.Models;
// using Conditional.Models;

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
        public int MarkId {get; set;}

// Navigation Properties
//        public Conditional Conditional {get; set;} = null!;
//        public Category Category {get; set;} = null!;
//        public Mark Mark {get; set;} = null!;

// Relationships
        public List<ProductImageModel> ProductImages {get; set;} = new();
        public List<HistoricalPriceModel> HistoricalPrices {get; set;} = new();
//        public List<StockProduct> StokProducts {get; set;} = new();

    }
}