using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface IWishListRepository
    {
        WishListItem GetWishListItem(int productId, int userId);

        void AddWishListItem(int productId, int userId, DateTime date);

        void DeleteWishListItemByProductId(int productId);

        IEnumerable<WishListItemDto> GetWishListItems(int userId);
    }
}
