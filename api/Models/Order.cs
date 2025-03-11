using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Order
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        public Guid? UserId {get; set;}
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotolPrice {get; set;} = 0;
        public string Status {get; set;} = string.Empty;
        public string PaymentMethod {get; set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    }
}