using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface ICartService
    {
        public void AddToCart(int productId, int userId);

        public void DeleteFromCart(int cartItemId);

        public IEnumerable<CartItemDto> GetCartItems();

        
    }
}
