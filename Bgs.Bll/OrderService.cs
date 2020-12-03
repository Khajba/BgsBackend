using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Enum;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bgs.Bll
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IUserService _userService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;


        public OrderService(
            IOrderRepository orderRepository,
            IUserService userService,
            ITransactionRepository transactionRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            ICartRepository cartRepository
            )

        {
            _userService = userService;
            _orderRepository = orderRepository;
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _cartRepository = cartRepository;

        }

        public IEnumerable<OrderDto> GetOrders(int userId, int pageNumber, int PageSize)
        {
            return _orderRepository.GetOrders(userId,pageNumber,PageSize);
        }

        public int GetOrdersCount(int userId)
        {
            return _orderRepository.GetOrdersCount(userId);
        }

        public void PlaceOrder(int userId)
        {
            var balance = _userRepository.GetBalance(userId);

            var cartItems = _cartRepository.GetCartItems(userId);

            var totalAmount = cartItems.Sum(x => x.Price * x.Quantity);

            balance = balance - totalAmount;

            if (balance < 0)
            {
                throw new BgsException((int)WebApiErrorCodes.NotEnoughBalance);
            }

            using (var transaction = new BgsTransactionScope())
            {
                _userRepository.UpdateBalance(userId, balance);

                foreach (var item in cartItems)
                {

                    var blocked = (int)_productRepository.GetBlockedProductQuantity(item.ProductId);
                    _productRepository.UpdateBlockedProductQuantity(item.ProductId, blocked - item.Quantity);

                    var stock = _productRepository.GetProductStock(item.ProductId) ?? 0;   
                    
                    if((stock - item.Quantity) < 0)
                    {
                        throw new BgsException((int)WebApiErrorCodes.OutOfStock);
                    }


                    _productRepository.UpdateProductStock(item.ProductId, stock - item.Quantity);
                }

                _transactionRepository.AddTransaction((int)TransactionType.Payment, userId, DateTime.Now, totalAmount);

                _cartRepository.DeleteCartItems(userId);

                var orderId = _orderRepository.AddOrder(userId, (int)OrderStatus.Pending, totalAmount, DateTime.Now, DateTime.Now);

                foreach (var item in cartItems)
                {
                    var amount = item.Price * item.Quantity;
                    _orderRepository.AddOrderItem(orderId, item.ProductId, item.Quantity, item.Price, amount);
                }

                transaction.Complete();
            }
        }

        public void UpdateOrderStatus(int orderId)
        {

        }
    }
}
