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


        public CartService(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            ITransactionRepository transactionRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
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

        public void PlaceOrder(int userId, int cartItemId, int productId, int quantity, decimal totalPrice)
        {
            var balance = _userRepository.GetBalance(userId);

            balance = balance - totalPrice;

            if (balance < 0)
            {
                throw new BgsException((int)WebApiErrorCodes.NotEnoughBalance);
            }

            else
            {
                using (var transaction = new BgsTransactionScope())
                {
                    _userRepository.UpdateBalance(userId, balance);

                    _transactionRepository.AddTransaction(
                        (int)TransactionType.Payment,
                        userId,
                        DateTime.Now,
                        totalPrice);

                    _productRepository.UpdateBlockedProductQuantity(productId, quantity);

                    var stock = _productRepository.GetProductStock(productId) ?? 0;

                    stock = stock - quantity;

                    _productRepository.UpdateProductStock(productId, stock);
                }


            }





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