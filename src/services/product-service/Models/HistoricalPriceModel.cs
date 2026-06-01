using Product.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoricalPrice.Models
{
    [Table("historical_price")]
    public class ProductHistoricalPriceModel
    {
        public int Id { get; set;}
        public int ProductId { get; set;}
        public decimal Price { get; set;}
        public DateTime StartDate { get; set;}
        public DateTime? EndDate { get; set; }
        public ProductModel Product {get; set;} = new ProductModel();
    }
}