using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Data.DTO;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Handler
{
    public class ClaimHandlerCommand : ResponseHandler , IRequestHandler<EditUserClaimCommand , Response<string>>
    {
        #region Fields
        private readonly IAuthorizationServices _authorizationServices;

        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constrctuor(s)

        public ClaimHandlerCommand(IAuthorizationServices authorizationServices, UserManager<ApplicationUser> userManager)
        {
            _authorizationServices=authorizationServices;
            _userManager=userManager;
        }


        #endregion

        #region Funcation Handler
        public async Task<Response<string>> Handle(EditUserClaimCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServices.EditUserClaimsAsync(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>("UserIsNull");
                case "InvalidRole": return BadRequest<string>("InvalidClaim");
                case "FailedToRemoveOldRoles": return BadRequest<string>("FailedToRemoveOldClaim");
                case "FailedToAddNewRoles": return BadRequest<string>("FailedToAddNewClaim");
                case "FailedToUpdateUserRoles": return BadRequest<string>("FailedToUpdateUserClaim");
            }

            return Success(result);

        }

        #endregion
    }
}
