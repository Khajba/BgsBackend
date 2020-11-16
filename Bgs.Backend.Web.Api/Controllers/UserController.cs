using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Web.Api.Controllers
{
    [Authorize]
    public class UserController : BgsController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getDetails")]
        public IActionResult GetDetails()
        {

            var userDetails = _userService.GetUserDetails(CurrentUserId);

            return Ok(userDetails);
        }

        [HttpGet("getUserAddress")]
        public IActionResult GetUserAddress()
        {
            var userAddress = _userService.GetUserAddress(CurrentUserId);

            return Ok(userAddress);
        }

        [HttpGet("getPaymentDetails")]
        public IActionResult GetUserPaymentDetails()
        {
            var paymentDetails = _userService.GetUserPaymentDetails(CurrentUserId);
            return Ok(paymentDetails);
        }
    }
}
