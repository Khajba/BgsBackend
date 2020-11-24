using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal.Abstract
{
    public interface IWishListRepository
    {
        void AddWishListItem(int productId, int userId, DateTime date);

        void DeleteWishListItem(int productId);

        IEnumerable<WishListItemDto> GetWishListItems(int userId);
    }
}
