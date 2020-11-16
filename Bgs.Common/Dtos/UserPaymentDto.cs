using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Common.Dtos
{
    public class UserPaymentDto
    {
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string Cvv2 { get; set; }
    }
}
