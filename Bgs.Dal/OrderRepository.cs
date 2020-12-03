using Bgs.Common.Dtos;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Bgs.Dal
{
    public class OrderRepository : SqlServerRepository, IOrderRepository
    {

        private const string _schemaUser = "Order";

        public OrderRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }

        public int AddOrder(int userId, int statusId, decimal totalAmount, DateTime createDate, DateTime statusUpdateDate)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.AddOrder"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("StatusId", statusId);
                cmd.AddParameter("TotalAmount", totalAmount);
                cmd.AddParameter("CreateDate", createDate);
                cmd.AddParameter("StatusUpdateDate", statusUpdateDate);

                return cmd.ExecuteReaderPrimitive<int>("OrderId");
            }
        }


        public void AddOrderItem(int orderId, int productId, int quantity, decimal price, decimal amount)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.AddOrderItem"))
            {

                cmd.AddParameter("OrderId", orderId);
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("Quantity", quantity);
                cmd.AddParameter("Price", price);
                cmd.AddParameter("Amount", amount);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<OrderDto> GetOrders(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetOrders"))
            {

                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReader<OrderDto>();
            }
        }

        public int GetOrdersCount(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetOrdersCount"))
            {

                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderPrimitive<int>("Count");
            }
        }

        public void UpdateOrderStatus(int orderId, int status)
        {
            using (var cmd = GetCommand($"{_schemaUser}.UpdateOrderStatus"))
            {
                cmd.AddParameter("Id", orderId);
                cmd.AddParameter("Status", status);

                cmd.ExecuteNonQuery();

            }
        }
    }
}
