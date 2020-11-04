using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Product
{
    public class AddProductAttachmentsModel
    {
        [Required]
        public int? ProductId { get; set; }

        [Required]
        public IEnumerable<IFormFile> Files { get; set; }
    }
}