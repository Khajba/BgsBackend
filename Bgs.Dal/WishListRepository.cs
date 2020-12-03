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
    public class WishListRepository : SqlServerRepository, IWishListRepository
    {
        private const string _schemaUser = "User";

        public WishListRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }

        public WishListItem GetWishListItem(int productId, int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetWishListItem"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderSingle<WishListItem>();
            }
        }

        public void AddWishListItem(int productId, int userId, DateTime date)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.AddWishListItem"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("CreateDate", date);
                

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteWishListItemByProductId(int productId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.DeleteWishListItemByProductId"))
            {
                cmd.AddParameter("ProductId", productId);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<WishListItemDto> GetWishListItems(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetWishListItems"))
            {
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReader<WishListItemDto>();
            }
        }
    }
}