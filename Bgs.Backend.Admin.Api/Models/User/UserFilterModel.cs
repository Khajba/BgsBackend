using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Models.User
{
    public class UserFilterModel
    {
        public string PinCode { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
