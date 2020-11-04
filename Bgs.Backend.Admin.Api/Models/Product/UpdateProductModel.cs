using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Product
{
    public class UpdateProductModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}