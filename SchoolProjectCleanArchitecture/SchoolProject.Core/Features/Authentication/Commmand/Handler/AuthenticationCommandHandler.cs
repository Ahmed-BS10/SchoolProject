using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commmand.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commmand.Handler
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                                IRequestHandler<SignCommand, Response<string>>
                                                ,IRequestHandler<SendResetPasswordCodeCommand , Response<string>>
                                                ,IRequestHandler<UpdatePasswordCommand , Response<string>>
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
        public async Task<Response<string>> Handle(SignCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return NotFound<string>();

            if (!user.EmailConfirmed)
                return BadRequest<string>("Un  EmailConfirmed");

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password,true);
            if (!signInResult.Succeeded) return BadRequest<string>();

            var accessToken = await  _authenticationServices.GenerateJWTToken(user);
            return Success(accessToken);
        }
        public async Task<Response<string>> Handle(SendResetPasswordCodeCommand request, CancellationToken cancellationToken)
        {
           var sendRestEmail = await _authenticationServices.SendResetPasswordCodeAsync(request.Email);
            switch(sendRestEmail)
            {
                case "UserNotFound": return NotFound<string>("UserNotFound");
                case "ErrorInUpdateUser": return BadRequest<string>("ErrorInUpdateUser");
                case "Success": return Success(sendRestEmail);
                default: return BadRequest<string>("Failed");


            }
        }

        public async Task<Response<string>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationServices.UpdatePassword(request.Email, request.Password);
            switch (result)
            {
                case "UserNotFound": return NotFound<string>("UserNotFound");
                case "Failed": return BadRequest<string>("Failed");
                default: return BadRequest<string>("some thinges");
            }
           
        }
        #endregion

    }
}
