using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public string Name {get; set;} = string.Empty;
        public string? Description {get; set;} = string.Empty; // Mô tả
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get; set;} = 0;
        public int StockQuantity {get; set;} = 0;
        ///---------------------------------
        public Guid? CategoryId {get; set;}
        ///----------------------------------
        ///
        ///----------------------------------
        public string ImageUrl {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
        public List<ProductVariant> ProductVariants {get; set;} = new List<ProductVariant>();
        public List<Review> Reviews {get; set;} = new List<Review>();


    }
}