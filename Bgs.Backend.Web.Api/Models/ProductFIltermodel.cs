using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Web.Api.Models
{
    public class ProductFilterModel
    {
        public string Name { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public int? CategoryId { get; set; }

        public int? PageNumber { get; set; } = 0;

        public int? PageSize { get; set; } = 10;

        public int? ArtistId { get; set; }

        public int? DesignerId { get; set; }

        public int? MechanicsId { get; set; }

        public int SortOrder { get; set; }
    }
}
