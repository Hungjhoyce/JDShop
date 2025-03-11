using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Payment
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        //------------
        public Guid? OrderId {get; set;}
        public Order? Order {get; set;}
        // -----------
        public string PaymentStatus {get; set;} = string.Empty;
        public string TransactionId {get; set;} = string.Empty;
        public DateTime PaymentDate {get; set;} = DateTime.UtcNow;

    }
}