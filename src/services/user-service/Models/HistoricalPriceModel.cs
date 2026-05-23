using Product.Models;

namespace HistoricalPrice.Models
{
    public class HistoricalPriceModel
    {
        public int Id { get; set;}
        public int ProductId { get; set;}
        public decimal Price { get; set;}
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}


         public ProductModel Product {get; set;} = new ProductModel();
    }
}