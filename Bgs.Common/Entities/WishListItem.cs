using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Entities
{
    public class WishListItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsFavorite { get; set; }
    }
}
