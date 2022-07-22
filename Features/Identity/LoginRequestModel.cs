using System.ComponentModel.DataAnnotations;

namespace BrianTech008Api.Features.Identity
{
    public class LoginRequestModel
    {

        [Required]
        public string UserName { get; set; }
        //[Required]
        //public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
