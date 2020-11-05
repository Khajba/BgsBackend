using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Product
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string Designer { get; set; }

        [Required]
        public string Mechanics { get; set; }
    }
}