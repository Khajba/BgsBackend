using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IOrderService
    {
        public IEnumerable<OrderItemDto> GetOrderItems(int userId);

        public void PlaceOrder(int userId, int cartItemId, int productId, int quantity, decimal totalPrice);
    }
}
