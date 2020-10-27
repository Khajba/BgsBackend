using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public ProductType Category { get; set; }
        [Required]
        public int? Stock { get; set; }
    }
}
