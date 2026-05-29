using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.Models;

namespace Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IReadOnlyList<ProductModel> GetAll()
        {
            return _context.Product
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }

        public ProductModel? GetById(int id)
        {
            return _context.Product
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public ProductModel Add(ProductModel product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Update(ProductModel product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }
    }
}