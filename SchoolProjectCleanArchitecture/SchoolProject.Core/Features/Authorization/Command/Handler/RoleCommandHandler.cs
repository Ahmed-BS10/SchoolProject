﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Core.Resources;
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
    public class RoleCommandHandler : ResponseHandler,
                                     IRequestHandler<AddRoleCommand, Response<string>>
                                     ,IRequestHandler<EditRoleCommand, Response<string>>
                                     ,IRequestHandler<DeleteRoleCommand, Response<string>>
                                     ,IRequestHandler<EditUserRolesCommand, Response<string>>
    {
        #region Fields
        private readonly IAuthorizationServices _authorizationServices;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constrctuor(s)
        public RoleCommandHandler(IAuthorizationServices authorizationServices, UserManager<ApplicationUser> userManager)
        {
            _authorizationServices=authorizationServices;
            _userManager=userManager;
        }
        #endregion

        #region Funcation Handler
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var IsroleExist = await _authorizationServices.IsRoleExistByNameAsync(request.RoleName);
            if (IsroleExist == true) return BadRequest<string>("Role Is Exist");

            var result =  await _authorizationServices.AddRoleAsyncAsync(request.RoleName);
            return result == "Success" ? Success("") : BadRequest<string>("Add Failed");

        }
        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var roleresult = await _authorizationServices.EditRoleAsync(request.Id, request.Name);
            if (roleresult == "Not Found") return NotFound<string>();
            else if (roleresult =="Success") return Success("");

            return BadRequest<string>(roleresult);

        }
        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            /// var IsRole = await _authorizationServices.IsRoleExistById(request.id);

            var roleResult = await _authorizationServices.DeleteRoleAsync(request.id);
            if (roleResult == "Not Found") return NotFound<string>();

            else if (roleResult == "role Use") return UnprocessableEntity<string>("Role Is already Used");

            else if (roleResult == "Success") return Success("");

            return BadRequest<string>();
        }
        public async Task<Response<string>> Handle(EditUserRolesCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServices.EditUserRolesAsync(request);
            switch(result)
            {
                case "UserIsNull": return NotFound<string>("UserIsNull");
                case "InvalidRole": return BadRequest<string>("InvalidRole");
                case "FailedToRemoveOldRoles": return BadRequest<string>("FailedToRemoveOldRoles");
                case "FailedToAddNewRoles": return BadRequest<string>("FailedToAddNewRoles");
                case "FailedToUpdateUserRoles": return BadRequest<string>("FailedToUpdateUserRoles");
            }

            return Success(result);
            
        }


        #endregion

    }
}
