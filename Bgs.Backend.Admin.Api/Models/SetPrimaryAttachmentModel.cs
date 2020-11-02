using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models
{
    public class SetPrimaryAttachmentModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int AttachmentId { get; set; }
        
    }
}
