using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Web.Api.Models
{
    public class AddCommentModel
    {
        [Required]
        public int? ProductId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
