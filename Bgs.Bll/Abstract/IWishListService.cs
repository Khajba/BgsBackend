using Bgs.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IWishListService
    {
        void AddToWishList(int productId, int userId);

        void RemoveFromWishList(int productId);

        IEnumerable<WishListItemDto> GetWishListItems(int userId);
    }
}
