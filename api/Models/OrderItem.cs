using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class OrderItem
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Guid? OrderId {get; set;}
        public Guid? ProducId {get; set;}
        public Guid? ProductVariantId {get; set;}
        public ProductVariant? ProductVariant {get; set;}
        public int Quantity {get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price {get; set;} = 0;
        public decimal Subtotal => Quantity * Price;
    }
}