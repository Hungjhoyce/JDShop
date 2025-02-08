using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ProductVariant;
using api.Dtos.Review;
using api.Models;

namespace api.Dtos.Product
{
    public class ProductDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty; // Mô tả
        
        public decimal Price {get; set;}
        public int Stock {get; set;} = 0; // SL
        ///---------------------------------
        public int? CategoryId {get; set;}
        ///----------------------------------
        public string Image {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public List<ProductVariantDto> ProductVariants {get; set;}
        public List<ReviewDto> reviews {get; set;}
    }
}