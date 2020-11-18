using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Dtos
{
    public class ProductDetailsDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public string PrimaryAttachmentUrl { get; set; }

        public IEnumerable<string> ProductAttachments {get;set;}

        public IEnumerable<Comment> Comments { get; set; }
    }
}
