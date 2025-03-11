using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Inventory
    {
        public Guid Id {get; set;} = Guid.NewGuid();
        // --------------
        public Guid? ProductId {get; set;}
        public int Stock {get; set;} = 0;
        public DateTime LastUpdated {get; set;} = DateTime.UtcNow;

    }
}