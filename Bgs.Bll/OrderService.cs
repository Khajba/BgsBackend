using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Enum;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IUserService _userService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IUserService userService,
            ITransactionRepository transactionRepository,
            IProductRepository productRepository,
            IUserRepository userRepository)

        {
            _userService = userService;
            _orderRepository = orderRepository;
            _transactionRepository = transactionRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;

        }

        public IEnumerable<OrderItemDto> GetOrderItems(int userId)
        {
            throw new NotImplementedException();
        }

        public void PlaceOrder(int userId, int cartItemId, int productId, int quantity, decimal totalAmount)
        {
            var balance = _userRepository.GetBalance(userId) ?? 0;

            balance = balance - totalAmount;

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
                        totalAmount);

                    _productRepository.UpdateBlockedProductQuantity(productId, quantity);

                    var stock = _productRepository.GetProductStock(productId) ?? 0;

                    stock = stock - quantity;

                    _productRepository.UpdateProductStock(productId, stock);

                    _orderRepository.AddOrderItem(userId, (int)OrderStatus.Pending, totalAmount, DateTime.Now);

                    transaction.Complete();

                }


            }





        }
    }
}
