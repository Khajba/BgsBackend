﻿using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System;
using System.Collections.Generic;

namespace Bgs.Dal.Abstract
{
    public interface ICartRepository
    {
        void AddCartItem(int productId, int userId, int quantity, DateTime createDate);

        void DeleteCartItem(int id);

        CartItem GetCartItem(int productId, int userId);

        IEnumerable<CartItemDto> GetCartItems(int userId);

        void UpdateCartItemQuantity(int id, int quantity);

        int GetCartItemsCount(int userId);
    }
}