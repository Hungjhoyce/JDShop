using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty; // Mô tả
        public decimal Price {get; set;}
        public int Stock {get; set;} = 0; // SL
        public string Image {get; set;} = string.Empty;
    }
}