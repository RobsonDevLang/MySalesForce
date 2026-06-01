using Product.DTO;
using Product.Models;

namespace Product.Mappers
{
    public class ProductMapper
    {
        public static ProductModel ParaModel(ProductDto dto)
        {
            return new ProductModel
            {
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                Status = dto.Status,
                Weight = dto.Weight,
                Height = dto.Height,
                Width = dto.Width,
                Observation = dto.Observation,
                ShortName = dto.ShortName,
                ConditionalId = dto.ConditionalId,
                Category = dto.Category != null ? new CategoryModel { Name = dto.Category } : null!,
                MarkId = dto.MarkId
            };
        }

        public static ProductDto ForDto(ProductModel model)
        {
            return new ProductDto
            {
                Code = model.Code,
                Name = model.Name,
                Description = model.Description,
                Status = model.Status,
                Weight = model.Weight,
                Height = model.Height,
                Width = model.Width,
                Observation = model.Observation,
                ShortName = model.ShortName,
                ConditionalId = model.ConditionalId,
                Category = model.Category?.Name ?? string.Empty,
                MarkId = model.MarkId,
            };
        }
    }
}