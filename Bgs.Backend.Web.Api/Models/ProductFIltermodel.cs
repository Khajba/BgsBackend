using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Web.Api.Models
{
    public class ProductFIltermodel
    {
        public string Name { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public int? CategoryId { get; set; }
        
        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }
    }
}
