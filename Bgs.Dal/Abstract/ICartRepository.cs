using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface ICartRepository
    {
        
        public void DeleteCartItem(int cartItemId);

        public IEnumerable<CartItemDto> GetCartItems(int userId);

        public CartItem GetCartItem(int productId, int userId);

        public void AddCartItem(int productId, int userId, int quantity, DateTime date);

        public void UpdateCartItemQuantity(int cartItemId, int quantity);

       
    }
}
