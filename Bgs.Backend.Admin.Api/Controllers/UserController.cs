using Bgs.Backend.Admin.Api.Models.User;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll([FromQuery] UserFilterModel filter)
        {
            var users = _userService.GetUsers(filter.PinCode, filter.Email, filter.Firstname, filter.Lastname);
            return Ok(users);
        }

        [HttpGet("getDetails")]
        public IActionResult GetDetails([Required] int userId)
        {
            var userDetails = _userService.GetDetails(userId);
            return Ok(userDetails);
        }

    }
}
