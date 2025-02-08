using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Review
    {
        public int Id {get; set;}
        [Column(TypeName = "range(1,5)")]
        public int Rating {get; set;}
        public string Comment {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public int? ProductId {get; set;}
        public Product? Product {get; set;}
    }
}