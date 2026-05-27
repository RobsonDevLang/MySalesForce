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
            return _context.Products
                .AsNoTracking()
                .ToList()
                .AsReadOnly();
        }

        public ProductModel? GetById(int id)
        {
            return _context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }

        public ProductModel Add(ProductModel product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Update(ProductModel product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}