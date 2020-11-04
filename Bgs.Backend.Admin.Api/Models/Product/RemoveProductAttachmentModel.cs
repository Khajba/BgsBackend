using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Product
{
    public class RemoveProductAttachmentModel
    {
        [Required]
        public int? AttachmentId { get; set; }
    }
}