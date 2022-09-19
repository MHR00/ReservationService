using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ReservationService.Entities.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReservationService.Services.JWT
{
    public class JwtService : IJwtService
    {

        public string Generate(ResultUserLoginDto users)
        {
            var secretKey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey");//longer than 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes("16CharEncryptKey"); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey),
                SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = _getClaims(users);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "MyWebsite",
                Audience = "MyWebsite",
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(0),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securiryToken = tokenHandler.CreateToken(descriptor);
            var jwt = tokenHandler.WriteToken(securiryToken);
            return jwt;
        }

        private IEnumerable<Claim> _getClaims(ResultUserLoginDto users)
        {
            var secutiryStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;
            var list = new List<Claim>
            {
                new Claim(ClaimTypes.Name, users.UserName),
                new Claim(ClaimTypes.NameIdentifier,users.Id.ToString()),
                //new Claim(ClaimTypes.MobilePhone, users.MobileNumber),
                //new Claim(secutiryStampClaimType , users.SecurityStamp.ToString()),
            };

            //var roles = new Role[] { new Role { Name = "Admin" } };
            //foreach (var role in roles)
            //    list.Add(new Claim(ClaimTypes.Role, role.Name));

            return list;
        }
    }
}
