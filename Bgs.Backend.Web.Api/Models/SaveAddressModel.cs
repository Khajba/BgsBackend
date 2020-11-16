using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Web.Api.Models
{
    public class SaveAddressModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
