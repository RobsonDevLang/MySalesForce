using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Size.Models;

namespace Product.Models
{
    public class ProductSizeModel
    {
    public int ProductId { get; set; }
    public ProductModel Product { get; set; } = null!;

    public int SizeId { get; set; }
    public SizeModel Size { get; set; } = null!;
    }
}