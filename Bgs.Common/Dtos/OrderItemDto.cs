using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
