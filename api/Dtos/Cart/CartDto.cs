using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Cart
{
    public class CartDto
    {
        public Guid Id {get; set;}
        public Guid? UserID {get; set;}
        public Guid? ProductId {get; set;}
        public Guid? ProductVariantId {get; set;}
        public int Quantity {get; set;} = 1;
    }
}