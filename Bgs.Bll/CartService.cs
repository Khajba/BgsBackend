using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository )
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        

        public void AddToCart(int productId, int userId)
        {
            var stock = _productRepository.GetProductAvailableStock(productId);
            

            if(stock == 0)
            {
                throw new BgsException((int)WebApiErrorCodes.OutOfStock);
            }

            else 
            {

                var cartItem = _cartRepository.GetCartItem(productId, userId);

                if(cartItem == null)
                {
                    _cartRepository.AddCartItem(productId, userId, 1, DateTime.Now);
                    
                }
                else
                {
                    _cartRepository.UpdateCartItemQuantity(cartItem.Id, cartItem.Quantity +1);
                    

                }
                Blockstock(productId, 1);
            }
        }

        public void DeleteFromCart(int cartItemId)
        {
            _cartRepository.DeleteCartItem(cartItemId);
        }

        public IEnumerable<CartItemDto> GetCartItems()
        {
            return _cartRepository.GetCartItems();
        }

        private void Blockstock(int productId, int quantity)
        {
            var stock = _cartRepository.GetBlockedStock(productId);
             if(stock == null)
            {
                _cartRepository.AddBlockedStock(productId, quantity);
            }
            else
            {
                _cartRepository.UpdateBlockedStock(productId, stock + quantity);
            }
        }
       
    }
}
