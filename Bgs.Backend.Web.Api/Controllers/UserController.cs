using Bgs.Backend.Web.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("getAccount")]
        public IActionResult GetDetails()
        {
            var userAccount = _userService.GetUserAccountDetails(CurrentUserId);

            return Ok(userAccount);
        }

        [HttpPost("saveDetails")]
        public IActionResult SaveDetails(SaveDetailsModel model)
        {
            _userService.SaveDetails(CurrentUserId, model.Firstname, model.Lastname);
            return Ok();
        }

        [HttpGet("getUserAddress")]
        public IActionResult GetUserAddress()
        {
            var userAddress = _userService.GetUserAddress(CurrentUserId);

            return Ok(userAddress);
        }

        [HttpPost("saveUserAddress")]
        public IActionResult SaveUserAddress(SaveAddressModel model)
        {
            _userService.SaveUserAddress(CurrentUserId, model.FullName, model.Line1, model.Line2, model.City, model.State, model.ZipCode, model.PhoneNumber);
            return Ok();
        }

        [HttpGet("getPaymentDetails")]
        public IActionResult GetUserPaymentDetails()
        {
            var paymentDetails = _userService.GetUserPaymentDetails(CurrentUserId);
            return Ok(paymentDetails);
        }

        [HttpPost("savePaymentDetails")]
        public IActionResult SavePaymentDetails(SavePaymentDetailsModel model)
        {
            _userService.SavePaymentDetails(CurrentUserId, model.CardholderName, model.CardNumber, model.ExpirationMonth, model.ExpirationYear, model.Cvv2);
            return Ok();
        }

        [HttpPost("changeUserPassword")]
        public IActionResult ChangeUserPassword(ChangeUserPasswordModel model)
        {
            _userService.ChangeUserPassword(CurrentUserId, model.OldPassword, model.NewPassword);
            return Ok();
        }

        [HttpPost("addBalance")]
        public IActionResult AddBalance([FromBody][Required] decimal amount)
        {
            _userService.AddBalance(CurrentUserId, amount);
            return Ok();
        }

        [HttpGet("getBalance")]
        public IActionResult GetBalance()
        {
            var balance = _userService.GetBalance(CurrentUserId);
            return Ok(balance);
        }

        [HttpPost("uploadUserAvatar")]
        public IActionResult UploadUserAvatar(IFormFile file)
        {
            var avatarUrl = _userService.UploadUserAvatar(CurrentUserId, file);
            return Ok(new UploadUserAvatarResponseModel { AvatarUrl = avatarUrl });
        }

        [HttpPost("removeAvatar")]
        public IActionResult RemoveAvatar()
        {
            _userService.DeleteAvatar(CurrentUserId);

            return Ok();
        }
    }
}