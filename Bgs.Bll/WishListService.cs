using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _wishListRepository;

        public WishListService(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

         public void AddToWishList(int productId, int userId)
        {
            _wishListRepository.AddWishListItem(productId, userId, DateTime.Now);
        }

         public void RemoveFromWishList(int productId)
        {
            _wishListRepository.DeleteWishListItemByProductId(productId);
        }

         public IEnumerable<WishListItemDto> GetWishListItems(int userId)
        {
            return _wishListRepository.GetWishListItems(userId);
        }
    }
}
