using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface IAuthenticationServices
    {
        //Task< JWTAuthResult> CreateTokenAsync(ApplicationUser applicationUser);
        //Task<JWTAuthResult> GetRefreshTokenAsync(string accessToken , string refreshToken);
        //Task <string> ValidateToken(string accessToken);
        Task<string> GenerateJWTToken(ApplicationUser user);
        // Email
        Task<string> ConfirmEmail(string userId, string code);

        //Password
        Task<string> SendResetPasswordCodeAsync(string email);
        Task<string> ConfirmResetPassword(string code, string email);
        Task<string> UpdatePassword(string email, string password);



    }
}
