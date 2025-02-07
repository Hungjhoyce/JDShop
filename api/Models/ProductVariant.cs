using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProductVariant
    {
        public int Id {get; set;}
        public int? ProductId {get; set;}
        public Product? Product {get; set;}
        public string Size {get; set;} = string.Empty;
        public string Color {get; set;} = string.Empty;
        public int Stock {get; set;} = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get; set;}


    }
}