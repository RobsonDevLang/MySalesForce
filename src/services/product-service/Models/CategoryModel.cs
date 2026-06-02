using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Models
{
    [Table("category")]
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ProductModel> Products { get; set; } = new();
    }
}