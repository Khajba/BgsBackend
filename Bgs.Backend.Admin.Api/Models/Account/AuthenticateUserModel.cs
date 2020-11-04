using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Admin.Api.Models.Account
{
    public class AuthenticateUserModel
    {
        [Required(ErrorMessage = "required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "required")]
        public string Password { get; set; }
    }
}