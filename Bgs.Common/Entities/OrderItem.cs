using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }    
        
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
