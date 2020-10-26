﻿using Bgs.Infrastructure.Api.Authorization;

namespace Bgs.Backend.Admin.Api.Models
{
    public class AuthenticationResponseModel
    {
        public string Email { get; set; }

        public JsonWebToken Jwt { get; set; }
    }
}