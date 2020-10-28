using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models
{
    public class ProductFilterModel
    {
        
        public string Name { get; set; }
        
        public float? PriceFrom { get; set; }
        public float? PriceTo { get; set; }       
        public int? CategoryId { get; set; }
        public int? StockFrom { get; set; }
        public int? StockTo { get; set; }

     
    }
}
