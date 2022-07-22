
using System;
using Microsoft.AspNetCore.Identity;

namespace BrianTech008Api.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public int UserTypeId { get; set; }
        public string Role { get; set; }
    }
}
