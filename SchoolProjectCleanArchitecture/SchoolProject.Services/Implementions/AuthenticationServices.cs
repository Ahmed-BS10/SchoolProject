using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolManagment.Data.Entities.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Infrastrcture.Abstracts;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementions
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IRefreshTokenRepoistory _refreshTokenRepoistory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        // private readonly ConcurrentDictionary<string,RefreshToken> _userRefreshTokens;
        public AuthenticationServices(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings, IRefreshTokenRepoistory refreshTokenRepoistory)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            // _userRefreshTokens=new ConcurrentDictionary<string, RefreshToken>();
            _refreshTokenRepoistory = refreshTokenRepoistory;
        }
        //public async Task <JWTAuthResult> CreateTokenAsync(ApplicationUser applicationUser )
        //{

        //    var (jwtToken,accessToken) = GenerateJWTToken(applicationUser);
        //    var refreshToken = GetRefreshToken(applicationUser.UserName);
        //    var userRefreshToken = new UserRefreshToken()
        //    {
        //        UserId = applicationUser.Id,
        //        JwtId = jwtToken.Id,
        //        CreatedAt = DateTime.UtcNow,
        //        ExpiryDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiration),
        //        IsUsed = false,
        //        IsRevoked = false,
        //        RefreshToken = refreshToken.ToString(),
        //        Token = accessToken

        //    };

        //   await _refreshTokenRepoistory.AddAsync(userRefreshToken);

        //    var _jwtToken = new JWTAuthResult()
        //    {
        //        AccessToken = token,
        //        RefreshToken = refreshToken
        //    };
        //  return _jwtToken;
        //}
        //private async Task<JWTAuthResult> GetRefreshToken(string accessToken , string refreshToken)
        //{
        //    // refresh token 
        //    #region Read And Validate Access Token  
        //    var jwtToken = ReadJWTToken(accessToken);



        //    var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "userId").Value;
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //        throw new SecurityTokenException("Invalid User Id");

        //    if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
        //        throw new SecurityTokenException("Algorithm Is Wrong");

        //    if (jwtToken.ValidTo > DateTime.UtcNow)
        //        throw new SecurityTokenException("Access Token Is Not Expired");

        //    #endregion

        //    #region Read And Validate Refresh Token  

        //    var userRefreshTokenRecord = await unitOfWork
        //                                      .Repository<UserRefreshToken>()
        //                                      .GetTableAsNotTracked()
        //                                      .FirstOrDefaultAsync(x => x.Token == accessToken &&
        //                                                           x.RefreshToken == refreshToken &&
        //                                                           x.UserId == int.Parse(userId));

        //    if (userRefreshTokenRecord == null)
        //        throw new SecurityTokenException("Invalid Refresh Token Operation");

        //    if (userRefreshTokenRecord.ExpiryDate < DateTime.UtcNow)
        //    {
        //        // refresh token is expired
        //        // revoke refresh token
        //        userRefreshTokenRecord.IsRevoked = true;
        //        userRefreshTokenRecord.IsUsed = false;
        //        await unitOfWork.Repository<UserRefreshToken>().UpdateAsync(userRefreshTokenRecord);
        //        throw new SecurityTokenException("Refresh Token Is Expired");
        //    }
        //    #endregion

        //    // right here you have a valid refresh token with an invalid access token
        //    //  update the access token of the current refresh token record
        //    var newAccessToken = new JwtSecurityTokenHandler().WriteToken(await GenerateJWTToken(user));

        //    userRefreshTokenRecord.Token = newAccessToken;
        //    await unitOfWork.Repository<UserRefreshToken>().UpdateAsync(userRefreshTokenRecord);

        //    var refreshTokenResult = new RefreshToken
        //    {
        //        UserName = user.UserName,
        //        Token = refreshToken,
        //        ExpiresOn = userRefreshTokenRecord.ExpiryDate
        //    };

        //    return new JwtAuthModel
        //    {
        //        RefreshToken = refreshTokenResult,
        //        AccessToken = newAccessToken
        //    };
        //}
        //private JwtSecurityToken ReadJWTToken(string accessToken)
        //{
        //    if (string.IsNullOrEmpty(accessToken))
        //        throw new ArgumentNullException(nameof(accessToken));

        //    var handler = new JwtSecurityTokenHandler();
        //    var response = handler.ReadJwtToken(accessToken);
        //    return response;
        //}
        //public async Task<authModle> GenerateJWTToken(ApplicationUser user)
        //{
        //    var _authModle = new authModle();
        //    // Claims Token

        //    var _claims = new List<Claim>()
        //    {

        //        new Claim(ClaimTypes.Name , user.UserName),
        //        new Claim(ClaimTypes.NameIdentifier , user.Id),
        //        new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString())
        //    };

        //    #region Role


        //    //var roles = await _userManager.GetRolesAsync(user);
        //    //foreach (var role in roles)
        //    //{
        //    //    claims.Add(new Claim(ClaimTypes.Role, role));
        //    //}
        //    #endregion


        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        //    var signincred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


        //    // Create Token
        //    var jwtToken = new JwtSecurityToken(
        //        issuer: _jwtSettings.Issuer,
        //        audience: _jwtSettings.Issuer,
        //        claims: _claims,
        //        expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpire),
        //        signingCredentials: signincred
        //        );
        //    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        //    if(user.UserRefreshTokens.Any(t => t.IsActive) || user.UserRefreshTokens is null)
        //    {
        //        var activeRefreshToken = user.UserRefreshTokens.FirstOrDefault(t => t.IsActive);
        //        _authModle.ResreshToken = activeRefreshToken.Token;
        //        _authModle.RefreshTokenExpiresOn= activeRefreshToken.ExpiresOn;
        //    }

        //    else
        //    {
        //        var refreshToken = GenerateRefreshToken();
        //        _authModle.ResreshToken = refreshToken.Token;
        //        _authModle.RefreshTokenExpiresOn= refreshToken.ExpiresOn;
        //        user.UserRefreshTokens.Add(refreshToken);
        //        await _userManager.UpdateAsync(user);
        //    }



        //    return _authModle;
        //}



        //private UserRefreshToken GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    var randomNumberGererate = new RNGCryptoServiceProvider();
        //    randomNumberGererate.GetBytes(randomNumber);

        //    return new UserRefreshToken
        //    {
        //        Token = Convert.ToBase64String(randomNumber),
        //        ExpiresOn = DateTime.UtcNow.AddDays(10),
        //    };
        //}

        //private RefreshToken GetRefreshToken(string userName)
        //{
        //    var refreshToken = new RefreshToken()
        //    {
        //        ExpireAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiration),
        //        UserName = userName,
        //        AccessRefreshTokenToken = GenerateRefreshToken()
        //    };
        //    _userRefreshTokens.AddOrUpdate(refreshToken.UserName, refreshToken, (s, t) => refreshToken);

        //    return refreshToken;
        //}

        //public Task<JWTAuthResult> GetRefreshTokenAsync(string accessToken, string refreshToken)
        //{
        //    throw new NotImplementedException();
        //}
        //public async Task<string> ValidateToken(string accessToken)
        //{

        //    var handler = new JwtSecurityTokenHandler();
        //    var parameters = GetValidationParameters();
        //    var validator = handler.ValidateToken(accessToken, parameters ,out SecurityToken security  );

        //    try
        //    {
        //        if (validator == null)
        //            throw new SecurityTokenException("jhjh");

        //        return "Successed";

        //    }
        //    catch (Exception ex)
        //    {

        //        return ex.Message;
        //    }
        //}
        //private TokenValidationParameters GetValidationParameters()
        //{
        //    return new TokenValidationParameters()
        //    {
        //        ValidateLifetime = true,
        //        ValidateAudience = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidateIssuer = true,
        //        ValidIssuer = _jwtSettings.Issuer,
        //        ValidAudience = _jwtSettings.Audience,
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),

        //    };
        //}



        public async Task<string> GenerateJWTToken(ApplicationUser user)
        {
            // Claims Token

            var _claims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.NameIdentifier , user.Id),
                new Claim(JwtRegisteredClaimNames.Jti ,Guid.NewGuid().ToString())
            };

            #region Role
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                _claims.Add(new Claim(ClaimTypes.Role, role));
            }
            #endregion

            #region UserClaims
            var userClaims = await _userManager.GetClaimsAsync(user);
            _claims.AddRange(userClaims);
            #endregion

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signincred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            // Create Token
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: _claims,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.AccessTokenExpire),
                signingCredentials: signincred
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);


            return accessToken;
        }

    }
}
