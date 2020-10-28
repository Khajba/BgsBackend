using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models
{
    public class UpdateProductModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float? Price { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
