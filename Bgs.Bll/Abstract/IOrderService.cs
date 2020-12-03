using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IOrderService
    {
        public IEnumerable<OrderDto> GetOrders(int userId, int? pageNumber, int? pageSize);

        public void UpdateOrderStatus(int orderId);

        public void PlaceOrder(int userId);

        public int GetOrdersCount(int userId);
    }
}
