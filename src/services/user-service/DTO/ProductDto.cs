<<<<<<< HEAD
using ProductService.Models;

namespace ProductService.DTO
=======
using Product.Models;

namespace Product.DTO
>>>>>>> a5add7858f623a71eae5e36b908238298d064667
{
    public class ProductDto
    {
        public string Code {get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
        public string Description { get; set;} = string.Empty;
        public int Status {get; set;} = 1;
        public decimal Weight {get; set;}
        public decimal Height {get; set;}
        public decimal Width { get; set;}
        public string? Observation {get; set;}
        public string? ShortName {get; set;}
<<<<<<< HEAD
    }
}
=======
        public int ConditionalId {get; set;}
        public int CategoryId { get; set;}
        public int MarkId {get; set;}
    }
}
>>>>>>> a5add7858f623a71eae5e36b908238298d064667
