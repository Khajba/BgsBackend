using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models
{
    public class AddProductStockModel
    {
        [Required]
        public int? ProductId { get; set; }

        [Required]
        public int? Quantity { get; set; }
    }
}