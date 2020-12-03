using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface IOrderRepository
    {
        public IEnumerable<OrderDto> GetOrders(int userId);

        public void UpdateOrderStatus(int orderId, int status);

        public void AddOrderItem(int orderId, int productId, int quantity, decimal price, decimal amount);

        public int AddOrder(int userId, int orderStatusId, decimal totalAmount, DateTime createDate, DateTime statusUpdateDate);

        public int GetOrdersCount(int userId);
    }
}
