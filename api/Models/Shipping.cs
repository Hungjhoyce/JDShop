using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace api.Models
{
    public class Shipping
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? OrderId { get; set; }
        public string ShippingMethod { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; } = 0;
        public string TrackingNumber { get; set; } = string.Empty;
        public string Status { get; set; } =  string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}