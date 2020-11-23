using System.Collections.Generic;

namespace Bgs.Common.Dtos
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public string PrimaryAttachmentUrl { get; set; }

        public IEnumerable<string> Attachments { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }
    }
}