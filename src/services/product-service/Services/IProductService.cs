using Product.Models;

namespace Product.Services
{
    public interface IProductService
    {
        IReadOnlyList<ProductModel> GetAll();
        ProductModel? GetById(int id);
        ProductModel Add(ProductModel product);
        void Update(ProductModel product);
    }
}
