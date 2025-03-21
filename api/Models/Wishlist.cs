using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Wishlist
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        // -----------
        public Guid? UserId {get; set;}
        public User? User {get; set;}
        // ----------
        // ---------
        public Guid? ProductId {get; set;}
        public Product? Product {get; set;}
        // ----------
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    }
}