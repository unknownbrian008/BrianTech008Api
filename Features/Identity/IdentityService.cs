using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BrianTech008Api.Data;
using BrianTech008Api.Data.Models;
using BrianTech008Api.Features.Identity;

namespace BrianTech008Api.Features.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly DataContext dc;

        public IdentityService(DataContext dc)
        {
            this.dc = dc;
        }
        public string GenerateJwtToken( string userId, string userName, string secret)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

          
            var tokenDescriptor = new SecurityTokenDescriptor
            {    
                Subject = new ClaimsIdentity(new[]
                { new Claim("id", userId.ToString()),
                new Claim(ClaimTypes.Role, "Operator")
                }),
               
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token); 
            //throw new NotImplementedException();
            return encryptedToken;
        }

        public bool CheckUserAvailabity(string userName)
        {
            string user = dc.Users.FirstOrDefault(x => x.UserName == userName)?.ToString();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
