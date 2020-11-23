using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }        

        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
