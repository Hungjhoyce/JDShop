using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty; // Mô tả
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get; set;}
        public int Stock {get; set;} = 0; // SL
        ///---------------------------------
        public int? CategoryId {get; set;}
        public Category? Category {get; set;}
        ///----------------------------------
        public string Image {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.Now;

    }
}