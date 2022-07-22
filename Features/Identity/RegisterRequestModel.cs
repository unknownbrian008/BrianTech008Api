using System.ComponentModel.DataAnnotations;

namespace BrianTech008Api.Features.Identity
{
    public class RegisterRequestModel
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }
        public int UserTypeId { get; set; }
        public string Role { get; set; }
    }
}
