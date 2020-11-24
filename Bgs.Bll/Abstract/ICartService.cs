using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface ICartService
    {
        public void AddCartItem(int productId, int userId);

        public void DeleteCartItem(int cartItemId);

        public IEnumerable<CartItemDto> GetCartItems(int userId);

        
    }
}
