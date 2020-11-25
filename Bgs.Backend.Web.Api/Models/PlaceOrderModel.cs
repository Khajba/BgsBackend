using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Web.Api.Models
{
    public class PlaceOrderModel
    {
        public int CartItemId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        
    }
}
