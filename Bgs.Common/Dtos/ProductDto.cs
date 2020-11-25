namespace Bgs.Common.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public string PrimaryAttachmentUrl { get; set; }

        public string Artist { get; set; }

        public string Designer { get; set; }

        public string Mechanics { get; set; }

        public bool IsInWishList { get; set; }
    }
}
