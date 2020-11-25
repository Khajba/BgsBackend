using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Dtos
{
    public class WishListItemDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public string PrimaryAttachmentUrl { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsFavorite { get; set; }
    }
}
