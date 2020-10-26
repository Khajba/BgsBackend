using System.Collections.Generic;

namespace Bgs.Infrastructure.Api.Authorization
{
    public interface IJwtHandler
    {
        string CreateToken(int userId, string role = null, IDictionary<string, string> claims = null);
    }
}