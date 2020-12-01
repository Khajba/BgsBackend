using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public int StatusId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastChangeDate { get; set; }
    }
}
