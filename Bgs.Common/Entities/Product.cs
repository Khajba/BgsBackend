﻿using System.Collections.Generic;

namespace Bgs.Common.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public string PrimaryAttachmentUrl { get; set; }

        public IEnumerable<ProductAttachment> Attachments { get; set; }
    }
}
