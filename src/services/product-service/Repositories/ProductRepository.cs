using Microsoft.EntityFrameworkCore;
using Product.Data;
using Product.DTO;
using Product.Models;
using Size.Models;

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

        public IReadOnlyList<ProductDto> GetAllActive()
        {
            return _context.Product
                .AsNoTracking()
                .Where(p => p.Status == 1)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Description = p.Description,
                    Status = p.Status,
                    Weight = p.Weight,
                    Height = p.Height,
                    Width = p.Width,
                    Observation = p.Observation,
                    ShortName = p.ShortName,
                    ConditionalId = p.ConditionalId,
                    Brand = p.Brand.Name,
                    Category = p.Category.Name,
                    Sizes = p.ProductSizes
                    .Select(ps => ps.Size.Size)
                            .ToList(),
                    Images = p.ProductImages
                    .Select(pi => new ProductImageDto
                    {
                        Url = pi.Url,
                        MainImage = pi.MainImage,
                        AltText = pi.AltText
                    })
                    .ToList(),
                    HistoricalPrices = p.ProductHistoricalPrices
                    .Where(hp => hp.EndDate == null)
                    .Select(pi => new ProductHistoricalPriceDto
                    {
                        Price = pi.Price,
                        StartDate = pi.StartDate,
                        EndDate = pi.EndDate
                    })
                    .ToList(),
                     
                })
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