using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using System;
using System.Collections.Generic;

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
            var item = _wishListRepository.GetWishListItem(productId, userId);

            if (item == null)

                _wishListRepository.AddWishListItem(productId, userId, DateTime.Now, true);

            else

                throw new BgsException((int)WebApiErrorCodes.ThisItemAlreadyInWishList);

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
