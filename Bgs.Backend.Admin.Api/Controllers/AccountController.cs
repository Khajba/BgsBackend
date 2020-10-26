using Bgs.Backend.Admin.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public ResponseMessage Login([FromQuery] LoginUserModel model)
        {
            _userService.AuthenticateUser(model.Email, model.Password);

            return new ResponseMessage
            {
                IsSeccess = true
            };
        }
    }
}
