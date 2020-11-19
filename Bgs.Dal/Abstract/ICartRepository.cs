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

        public IEnumerable<CartItemDto> GetCartItems();

        public CartItem GetCartItem(int productId, int userId);

        public void AddCartItem(int productId, int userId, int quantity, DateTime date);

        public void UpdateCartItemQuantity(int cartItemId, int quantity);

        public void AddBlockedStock(int productId, int? quantity);
        public void UpdateBlockedStock(int productId, int? quantity);
        public int? GetBlockedStock(int productId);
    }
}
