using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Product
{
    public class SetProductPrimaryAttachmentModel
    {
        [Required]
        public int? ProductId { get; set; }

        [Required]
        public int? AttachmentId { get; set; }
    }
}