using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Cart
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        // ---------------------
        public Guid? UserID {get; set;}
        public Guid? ProductId {get; set;}
        // ---------------------
        // ---------------------
        public Guid? ProductVariantId {get; set;}
        public ProductVariant? ProductVariant {get; set;}
        public int Quantity {get; set;} = 1;
        public DateTime AddedAt {get; set;} = DateTime.UtcNow;

    }
}