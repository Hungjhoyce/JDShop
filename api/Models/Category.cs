using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Category
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Description {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public List<Product> Products {get; set;} = new List<Product>();
    }
}