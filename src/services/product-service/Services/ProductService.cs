using Product.DTO;
using Product.Models;
using Product.Repositories;

namespace Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IReadOnlyList<ProductModel> GetAll() =>
            _repository.GetAll();

        public IReadOnlyList<CategoryDto> GetCategory() =>
            _repository.GetCategory();

        public IReadOnlyList<ProductDto> GetAllActive() =>
            _repository.GetAllActive();

        public IReadOnlyList<ProductDto> GetAllActiveCategory(int CategoryId) =>
            _repository.GetAllActiveCategory(CategoryId);

        public ProductModel? GetById(int id) =>
            _repository.GetById(id);

        public ProductModel Add(ProductModel product) =>
            _repository.Add(product);

        public void Update(ProductModel product) =>
            _repository.Update(product);
    }
}