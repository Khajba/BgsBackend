using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }        

        public decimal TotalAmount { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StatusUpdateDate { get; set; }
    }
}
