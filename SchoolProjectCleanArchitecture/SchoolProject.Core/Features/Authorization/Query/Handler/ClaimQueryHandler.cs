using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Query.Modle;
using SchoolProject.Data.DTO;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Query.Handler
{
    public class ClaimQueryHandler : ResponseHandler, IRequestHandler<ManagerUserClaimQuery, Response<ManagerUserWithClaimDto>>
    {
        #region Fieleds
        private readonly IAuthorizationServices _authorizationServices;
        private readonly UserManager<ApplicationUser> _userManager;


        #endregion
        #region Constrcutor(s)
        public ClaimQueryHandler(IAuthorizationServices authorizationServices, UserManager<ApplicationUser> userManager)
        {
            _authorizationServices=authorizationServices;
            _userManager=userManager;
        }
        #endregion

        #region MyRegion

        #endregion
        public async Task<Response<ManagerUserWithClaimDto>> Handle(ManagerUserClaimQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user == null) return NotFound<ManagerUserWithClaimDto>();

            var userClaims = await _authorizationServices.ManageUserClaimsAsync(user);
            if (userClaims == null) return BadRequest<ManagerUserWithClaimDto>();

            return Success(userClaims);
        }
    }
}
