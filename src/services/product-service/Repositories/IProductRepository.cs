using Product.DTO;
using Product.Models;

namespace Product.Repositories
{
    public interface IProductRepository
    {
        IReadOnlyList<ProductModel> GetAll();
        IReadOnlyList<CategoryDto> GetCategory();
        IReadOnlyList<ProductDto> GetAllActive();
        IReadOnlyList<ProductDto> GetAllActiveCategory(int CategoryId);
        ProductModel? GetById(int id);
        ProductModel Add(ProductModel product);
        void Update(ProductModel product);
    }
}
