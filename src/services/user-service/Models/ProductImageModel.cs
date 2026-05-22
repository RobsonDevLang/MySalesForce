using Product.Models;

namespace ProductImage.Models
{
    public class ProductImageModel
    {
        public int Id { get; set;}
        public int ProductId {get; set;}
        public string Url {get; set;} = string.Empty;
        public int Order { get; set;}
        public string MainImage {get; set;} = string.Empty;
        public string AltText {get; set;} = string.Empty;

        public ProductModel Product {get; set;} = new ProductModel();

    }
}