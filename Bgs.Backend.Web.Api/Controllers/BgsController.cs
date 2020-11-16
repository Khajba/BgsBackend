using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Bgs.Backend.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BgsController : ControllerBase
    {
        protected int CurrentUserId =>
            int.Parse(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
    }
}