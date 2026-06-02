using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.DTO
{
    public class ProductImageDto
    {
            public string Url { get; set; } = string.Empty;
            public bool MainImage { get; set; }
            public string AltText { get; set; } = string.Empty;
    }
}