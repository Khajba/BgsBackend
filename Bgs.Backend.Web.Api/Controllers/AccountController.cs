using Bgs.Backend.Web.Api.Models;
using Bgs.Bll.Abstract;
using Bgs.Infrastructure.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;

        public AccountController(IUserService userService, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(RegisterUserModel model)
        {
            _userService.RegisterUser(model.Email, model.Firstname, model.Lastname, model.Password);
            return Ok();
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }


        [HttpGet("login")]
        public IActionResult Login([FromQuery] LoginUserModel model)
        {
            var user = _userService.AuthenticateUser(model.Email, model.Password);

            var jwt = _jwtHandler.CreateToken(user.Id);

            return Ok(new AuthenticationResponseModel
            {
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Jwt = jwt
            });
        }

        [HttpGet("refreshToken")]
        [Authorize]
        public IActionResult RefreshToken()
        {
            var jwt = _jwtHandler.RefreshToken(User.Claims);

            return Ok(jwt);
        }
    }
}
