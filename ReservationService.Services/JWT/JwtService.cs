using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReservationService.Common;
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
        private readonly SiteSettings _siteSetting;

        public JwtService(IOptionsSnapshot<SiteSettings> settings)
        {
            _siteSetting = settings.Value;
        }

        public string Generate(ResultUserLoginDto users)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.SecretKey);//longer than 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.Encryptkey); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey),
                SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = _getClaims(users);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _siteSetting.JwtSettings.Issuer,
                Audience = _siteSetting.JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSetting.JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddHours(_siteSetting.JwtSettings.ExpirationMinutes),
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
                new Claim(ClaimTypes.MobilePhone, users.MobileNumber),
                //new Claim(secutiryStampClaimType , users.SecurityStamp.ToString()),
            };

            var roles = new Role[] { new Role { Name = "Admin" } , new Role { Name = "User" } };
            foreach (var role in roles)
                list.Add(new Claim(ClaimTypes.Role, role.Name));

            return list;
        }
    }
}
