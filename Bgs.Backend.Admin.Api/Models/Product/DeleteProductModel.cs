using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Product
{
    public class DeleteProductModel
    {
        [Required]
        public int? Id { get; set; }
    }
}