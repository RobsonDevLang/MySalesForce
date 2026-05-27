using Product.Models;

namespace Product.Repositories
{
    public interface IProductRepository
    {
        IReadOnlyList<ProductModel> GetAll();
        ProductModel? GetById(int id);
        ProductModel Add(ProductModel product);
        void Update(ProductModel product);
    }
}
