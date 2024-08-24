using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commmand.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commmand.Handler
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                                IRequestHandler<SignCommand, Response<JWTAuthResult>>
    {

        #region Field
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthenticationServices _authenticationServices;

        public AuthenticationCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthenticationServices authenticationServices)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _authenticationServices=authenticationServices;
        }

        #endregion

        #region Constrcutor(s)
        #endregion

        #region Funcation Handler
        public async Task<Response<JWTAuthResult>> Handle(SignCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return NotFound<JWTAuthResult>();
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password,true);
            if (!signInResult.Succeeded) return BadRequest<JWTAuthResult>();
            var accessToken =  _authenticationServices.CreateTokenAsync(user);
            return Success(accessToken);
        }
        #endregion

    }
}
