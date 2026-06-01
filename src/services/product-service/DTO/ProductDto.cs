
using Product.Models;

namespace Product.DTO
{
    public class ProductDto
    {
        public int Id {get; set;}
        public string Code {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
        public string Description { get; set;} = string.Empty;
        public int Status {get; set;} = 1;
        public decimal Weight {get; set;}
        public decimal Height {get; set;}
        public decimal Width { get; set;}
        public string? Observation {get; set;}
        public string? ShortName {get; set;}
        public int ConditionalId {get; set;}
        public string Category { get; set; } = string.Empty;
        public int MarkId {get; set;}
        public List<string> Sizes { get; set; } = new();
        public List<ProductImageDto> Images { get; set; } = new();
        public List<ProductHistoricalPriceDto> HistoricalPrices { get; set; } = new();
     }
}
