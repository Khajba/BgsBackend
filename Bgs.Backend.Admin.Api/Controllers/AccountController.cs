using Bgs.Backend.Admin.Api.Models;
using Bgs.Bll.Abstract;
using Bgs.Infrastructure.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IInternalUserService _internaluserService;
        private readonly IJwtHandler _jwtHandler;

        public AccountController(IInternalUserService internalUserService, IJwtHandler jwtHandler)
        {
            _internaluserService = internalUserService;
            _jwtHandler = jwtHandler;
        }

        [HttpGet("login")]
        public ResponseMessage Login([FromQuery] LoginUserModel model)
        {
            var internalUser = _internaluserService.AuthenticateUser(model.Email, model.Password);
            var token = _jwtHandler.CreateToken(internalUser.Id);
            return new ResponseMessage<string>
            {
                IsSeccess = true,
                Data = token

            };
        }
    }
}
