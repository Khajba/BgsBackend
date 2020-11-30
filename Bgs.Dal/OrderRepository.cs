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

        public void AddOrderItem(int userId, int orderStatusId, decimal totalAmount, DateTime createDate)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.AddCartItem"))
            {

                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("OrderStatusId", orderStatusId);
                cmd.AddParameter("TotalAmount", totalAmount);
                cmd.AddParameter("CreateDate", createDate);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<OrderItemDto> GetOrderItems(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetOrderItems"))
            {

                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderClosed<OrderItemDto>();
            }
        }
    }
}
