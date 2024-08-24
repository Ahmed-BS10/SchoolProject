using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Auth
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ConcurrentDictionary<string,RefreshToken> _userRefreshTokens;

        public AuthenticationServices(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings)
        {
            _userManager=userManager;
            _jwtSettings=jwtSettings;
            _userRefreshTokens=new ConcurrentDictionary<string,RefreshToken>();
        }

        public async Task<JWTAuthResult> CreateTokenAsync(ApplicationUser applicationUser )
        {
           
            // Claims Token

            var _claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , applicationUser.UserName),
                new Claim(ClaimTypes.NameIdentifier , applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString())
            };

            // Get Role 
            //var roles = await _userManager.GetRolesAsync(user);
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signincred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            // Create Token
            var AccessToken = new JwtSecurityToken(
                issuer:_jwtSettings.Issuer,
                audience:_jwtSettings.Issuer,
                claims:_claims,
                expires : DateTime.UtcNow.AddMinutes(2),
                signingCredentials : signincred
                );


            var token = new JwtSecurityTokenHandler().WriteToken(AccessToken);

          return token;
        }
    }
}
