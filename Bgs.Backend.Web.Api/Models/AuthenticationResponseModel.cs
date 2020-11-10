using Bgs.Infrastructure.Api.Authorization;

namespace Bgs.Backend.Web.Api.Models
{
    public class AuthenticationResponseModel
    {
        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public JsonWebToken Jwt { get; set; }
    }
}
