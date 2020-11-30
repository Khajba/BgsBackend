using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface IOrderRepository
    {
        public IEnumerable<OrderItemDto> GetOrderItems(int userId);

        public void AddOrderItem(int userId, int orderStatusId, decimal totalAmount, DateTime createDate);
    }
}
