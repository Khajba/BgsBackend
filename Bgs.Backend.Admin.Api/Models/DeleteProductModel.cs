using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models
{
    public class DeleteProductModel
    {
        [Required]
        public int Id { get; set; }
    }
}
