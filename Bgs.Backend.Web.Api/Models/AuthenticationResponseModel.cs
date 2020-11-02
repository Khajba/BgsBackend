using Bgs.Infrastructure.Api.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Web.Api.Models
{
    public class AuthenticationResponseModel
    {
        public string Email { get; set; }

        public JsonWebToken Jwt { get; set; }
    }
}
