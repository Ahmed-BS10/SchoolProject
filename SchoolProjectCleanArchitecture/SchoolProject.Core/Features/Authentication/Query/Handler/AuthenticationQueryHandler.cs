using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Query.Modles;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Services.Abstracts;


namespace SchoolProject.Core.Features.Authentication.Query.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                              IRequestHandler<ConfirmEmailQuery, Response<string>>,
                                              IRequestHandler<ConfirmRestPasswordEmailQuery, Response<string>>
      
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationServices _authenticationService;

        public AuthenticationQueryHandler(UserManager<ApplicationUser> userManager, IAuthenticationServices authenticationService)
        {
            _userManager=userManager;
            _authenticationService=authenticationService;
        }

        
        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmail (request.UserId, request.Code);


            switch (confirmEmail)
            {
                case "ErrorWhileConfirmingEmail": return NotFound<string>("ErrorWhileConfirmingEmail");
                case "UserNotFount": return NotFound<string>("UserNotFount");
                case "Success": return Success<string>("");
            }

            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(ConfirmRestPasswordEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmPasswordEmail = await _authenticationService.ConfirmResetPassword(request.Email, request.Code);
            switch(confirmPasswordEmail)
            {
                case "Success": return Success(confirmPasswordEmail);
                case "Failed": return BadRequest<string>("Failed");
                default : return BadRequest<string>("hi");
            }
        }
    }
}
