using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProductVariant
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Guid? ProductId {get; set;}
        public string Size {get; set;} = string.Empty;
        public string Color {get; set;} = string.Empty;
        public int Stock {get; set;} = 0;
        public string ImageUrl { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get; set;} = 0;


    }
}