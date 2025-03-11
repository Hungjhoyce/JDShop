using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Inventory
{
    public class InventoryDto
    {
        public Guid Id {get; set;}
        public int Stock {get; set;} = 0;
        public Guid? ProductId {get; set;}

    }
}