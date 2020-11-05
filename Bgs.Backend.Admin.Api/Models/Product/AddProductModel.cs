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
        public int? ArtistId { get; set; }

        [Required]
        public int? DesignerId { get; set; }

        [Required]
        public int? MechanicsId { get; set; }
    }
}