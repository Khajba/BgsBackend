using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal
{
    public class CartRepository : SqlServerRepository, ICartRepository
    {
        private const string _schemaCart = "Cart";

        public CartRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }

        

        public void AddBlockedStock(int productId, int? quantity)
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.AddBlockedStock"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        public void AddCartItem(int productId, int userId, int quantity, DateTime date)
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.AddCartItem"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("Quantity", quantity);
                cmd.AddParameter("Date", date);


                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCartItem(int cartItemId)
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.DeleteCartItem"))
            {
                cmd.AddParameter("ProductId", cartItemId);


                cmd.ExecuteNonQuery();
            }
        }

        public int? GetBlockedStock(int productId)
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.GetBlockedStock"))
            {
                cmd.AddParameter("ProductId", productId);              


                return cmd.ExecuteReaderPrimitive<int?>("stock");
            }
        }

        public CartItem GetCartItem(int productId, int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.GetCartItem"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);


                return cmd.ExecuteReaderSingleClosed<CartItem>();
            }
        }

        public IEnumerable<CartItemDto> GetCartItems()
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.GetCartItems"))
            {

                return cmd.ExecuteReaderClosed<CartItemDto>();
            }
        }

        public void UpdateBlockedStock(int productId, int? quantity)
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.UpdateBlockedStock"))
            {

                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCartItemQuantity(int cartItemId, int quantity)
        {
            using (var cmd = GetSpCommand($"{_schemaCart}.UpdateProductQuantity"))
            {

                cmd.AddParameter("CartItemId", cartItemId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
