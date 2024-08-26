using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Handler
{
    public class RoleCommandHandler : ResponseHandler,
                                     IRequestHandler<AddRoleCommand, Response<string>>
    {
        #region Fields
        private readonly IAuthorizationServices _authorizationServices;
        #endregion

        #region Constrctuor(s)
        public RoleCommandHandler(IAuthorizationServices authorizationServices)
        {
            _authorizationServices=authorizationServices;
        }
        #endregion

        #region Funcation Handler
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var IsroleExist = await _authorizationServices.IsRoleExist(request.RoleName);
            if (IsroleExist == true) return BadRequest<string>("Role Is Exist");

            var result =  await _authorizationServices.AddRoleAsync(request.RoleName);
            return result == "Success" ? Success("") : BadRequest<string>("Add Failed");

        }
        #endregion

    }
}
