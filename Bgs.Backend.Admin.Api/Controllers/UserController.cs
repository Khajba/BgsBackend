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
        private readonly IOrderService _orderService;

        public UserController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll([FromQuery] UserFilterModel filter)
        {
            var users = _userService.GetUsers(filter.PinCode, filter.Email, filter.Firstname, filter.Lastname, filter.PageNumber,filter.PageSize);
            return Ok(users);
        }

        [HttpGet("getDetails")]
        public IActionResult GetDetails([Required] int userId)
        {
            var userDetails = _userService.GetDetails(userId);
            return Ok(userDetails);
        }

        [HttpGet("getUsersCount")]
        public IActionResult GetUsersCount([FromQuery] UserFilterModel filter)
        {
            var count = _userService.GetUsersCount(filter.PinCode, filter.Email, filter.Firstname, filter.Lastname);
            return Ok(count);
        }

        [HttpGet("getOrdersCount")]
        public IActionResult GetOrdersCount([Required] int userId)
        {
            _orderService.GetOrdersCount(userId);
            return Ok();
        }

    }
}
