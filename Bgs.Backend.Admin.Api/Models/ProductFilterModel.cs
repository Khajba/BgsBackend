namespace Bgs.Backend.Admin.Api.Models
{
    public class ProductFilterModel
    {
        public string Name { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public int? CategoryId { get; set; }

        public int? StockFrom { get; set; }

        public int? StockTo { get; set; }
    }
}
