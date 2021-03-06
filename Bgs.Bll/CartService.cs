using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Enum;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
using System;
using System.Collections.Generic;

namespace Bgs.Bll
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IOrderRepository _orderRepository;


        public CartService(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            ITransactionRepository transactionRepository,
            IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _orderRepository = orderRepository;
        }

        public void AddCartItem(int productId, int userId)
        {
            var stock = _productRepository.GetProductAvailableStock(productId);

            if (stock == 0)
            {
                throw new BgsException((int)WebApiErrorCodes.OutOfStock);
            }
            else
            {
                var cartItem = _cartRepository.GetCartItem(productId, userId);

                using (var transaction = new BgsTransactionScope())
                {
                    if (cartItem == null)
                    {
                        _cartRepository.AddCartItem(productId, userId, 1, DateTime.Now);
                    }
                    else
                    {
                        _cartRepository.UpdateCartItemQuantity(cartItem.Id, cartItem.Quantity + 1);
                    }

                    BlockStock(productId, 1);

                    transaction.Complete();
                }
            }
        }

        public void DeleteCartItem(int cartItemId)
        {
            _cartRepository.DeleteCartItem(cartItemId);
        }

        public IEnumerable<CartItemDto> GetCartItems(int userId)
        {
            return _cartRepository.GetCartItems(userId);
        }

        public int GetCartItemsCount(int userId)
        {
            return _cartRepository.GetCartItemsCount(userId);
        }

        public void UpdateCartItemQuantity(int cartItemId, int quantity)
        {
            _cartRepository.UpdateCartItemQuantity(cartItemId, quantity);
        }

        
        private void BlockStock(int productId, int quantity)
        {
            var stock = _productRepository.GetBlockedProductQuantity(productId);

            if (stock == null)
            {
                _productRepository.AddBlockedProduct(productId, quantity);
            }
            else
            {
                _productRepository.UpdateBlockedProductQuantity(productId, stock + quantity);
            }
        }
    }
}