using Bgs.Common.Dtos;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal
{
    public class WishListRepository: SqlServerRepository, IWishListRepository
    {
        private const string _schemaWishList = "WishList";

        public WishListRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }
        public void AddWishListItem(int productId, int userId, DateTime date)
        {
            using (var cmd = GetSpCommand($"{_schemaWishList}.AddWishListItem"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("CreateDate", date);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteWishListItem(int productId)
        {
            using (var cmd = GetSpCommand($"{_schemaWishList}.DeleteWishListItem"))
            {
                cmd.AddParameter("ProductId", productId);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<WishListItemDto> GetWishListItems(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaWishList}.GetWishListItems"))
            {
                cmd.AddParameter("UserId", userId);
                return cmd.ExecuteReaderClosed<WishListItemDto>();
            }
        }

        
    }
}
