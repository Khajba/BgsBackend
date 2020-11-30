using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Bgs.Dal
{
    public class CartRepository : SqlServerRepository, ICartRepository
    {
        private const string _schemaUser = "User";

        public CartRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }

        public void AddCartItem(int productId, int userId, int quantity, DateTime date)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.AddCartItem"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("Quantity", quantity);
                cmd.AddParameter("CreateDate", date);


                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCartItem(int cartItemId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.DeleteCartItem"))
            {
                cmd.AddParameter("Id", cartItemId);

                cmd.ExecuteNonQuery();
            }
        }

        public CartItem GetCartItem(int productId, int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetCartItem"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderSingleClosed<CartItem>();
            }
        }

        public IEnumerable<CartItemDto> GetCartItems(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetCartItems"))
            {
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderClosed<CartItemDto>();
            }
        }

        public int GetCartItemsCount(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetCartItems"))
            {
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderPrimitive<int>("count");
            }
        }

        public void UpdateCartItemQuantity(int cartItemId, int quantity)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.UpdateCartItemQuantity"))
            {
                cmd.AddParameter("Id", cartItemId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }
    }
}