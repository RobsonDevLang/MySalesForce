using Product.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductImage.Models
{
    [Table("product_image")]
    public class ProductImageModel
    {
        public int Id { get; set;}
        public int ProductId {get; set;}
        public string Url {get; set;} = string.Empty;
        public int Order { get; set;}
        public bool MainImage {get; set;}
        public string AltText {get; set;} = string.Empty;
        public ProductModel Product { get; set; } = null!;

    }
}