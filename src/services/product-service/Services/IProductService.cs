using Product.DTO;
using Product.Models;

namespace Product.Services
{
    public interface IProductService
    {
        IReadOnlyList<ProductModel> GetAll();
        IReadOnlyList<ProductDto> GetAllActive();
        IReadOnlyList<CategoryDto> GetCategory();
        IReadOnlyList<ProductDto> GetAllActiveCategory(int CategoryId);
        ProductModel? GetById(int id);
        ProductModel Add(ProductModel product);
        void Update(ProductModel product);
    }
}
