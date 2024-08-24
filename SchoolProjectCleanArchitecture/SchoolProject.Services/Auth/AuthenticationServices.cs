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
using System.Security.Cryptography;
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

        public JWTAuthResult CreateTokenAsync(ApplicationUser applicationUser )
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
            var jwtToken = new JwtSecurityToken(
                issuer:_jwtSettings.Issuer,
                audience:_jwtSettings.Issuer,
                claims:_claims,
                expires : DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpire),
                signingCredentials : signincred
                );


            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
           var refreshToken = GetRefreshToken(applicationUser.UserName);
            var _jwtToken = new JWTAuthResult()
            {
                AccessToken = token,
                RefreshToken = refreshToken
            };
          return _jwtToken;
        }

        private RefreshToken GetRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken()
            {
                ExpireAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiration),
                UserName = userName,
                AccessRefreshTokenToken = GenerateRefreshToken()
            };
            _userRefreshTokens.AddOrUpdate(refreshToken.UserName, refreshToken, (s, t) => refreshToken);

            return refreshToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGererate = RandomNumberGenerator.Create();
            randomNumberGererate.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
