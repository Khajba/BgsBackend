using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Web.Api.Models
{
    public class SavePaymentDetailsModel
    {
        [Required]
        public string CardholderName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public int ExpirationMonth { get; set; }
        [Required]
        public int ExpirationYear { get; set; }
        [Required]
        public string Cvv2 { get; set; }
    }
}
