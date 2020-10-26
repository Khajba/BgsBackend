using System;

namespace Bgs.Infrastructure.Api.Authorization
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }

        public long Expires { get; set; }
    }
}