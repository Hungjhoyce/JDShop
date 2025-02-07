using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.ProductVariant
{
    public class CreateProductVariantDto
    {
        public string Size {get; set;} = string.Empty;
        public string Color {get; set;} = string.Empty;
        public int Stock {get; set;} = 0;
        public decimal Price {get; set;}
    }
}