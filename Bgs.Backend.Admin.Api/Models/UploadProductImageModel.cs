using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models
{
    public class UploadProductImageModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public IEnumerable<IFormFile> Files { get; set; }

    }
}
