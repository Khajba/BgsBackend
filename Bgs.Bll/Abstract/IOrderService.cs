using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IOrderService
    {
        public IEnumerable<OrderItemDto> GetOrderItems(int userId);
    }
}
