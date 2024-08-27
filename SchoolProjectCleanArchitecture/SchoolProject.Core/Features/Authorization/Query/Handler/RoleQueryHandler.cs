using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commmand.Models;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Core.Features.Authorization.Query.Modle;
using SchoolProject.Core.Features.Authorization.Respones;
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
    public class RoleQueryHandler : ResponseHandler
                                   ,IRequestHandler<GeyRoleByIdQuery, Response<GeyRoleByIdQueryResponse>>
                                   ,IRequestHandler<GeyRoleListQuery, Response<IEnumerable<GeyRoleListQueryResponse>>>
                                   ,IRequestHandler<GetUserWithRolesQuery, Response<GetUserWithRolesDto>>
    {

        #region Fields
        private readonly IAuthorizationServices _authorizationServices;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constrctuor(s)
        public RoleQueryHandler(IAuthorizationServices authorizationServices, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _authorizationServices=authorizationServices;
            _mapper=mapper;
            _userManager=userManager;
        }
        #endregion

        #region Funcation Handler
        public async Task<Response<GeyRoleByIdQueryResponse>> Handle(GeyRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var IsRoleExist = await _authorizationServices.IsRoleExistByIdAsync(request.Id);
            if (!IsRoleExist) return NotFound<GeyRoleByIdQueryResponse>();

            var role = await _authorizationServices.GetRoleByIdAsync(request.Id);
            var roleMapper = _mapper.Map<GeyRoleByIdQueryResponse>(role);
            return Success<GeyRoleByIdQueryResponse>(roleMapper, "Get Successed");
        }

        public async Task<Response<IEnumerable<GeyRoleListQueryResponse>>> Handle(GeyRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationServices.GetRoleList();
            if (roles == null)  return NotFound<IEnumerable<GeyRoleListQueryResponse>>("Not Found Roles ");

            var rolesMapper = _mapper.Map<IEnumerable<GeyRoleListQueryResponse>>(roles);
            return Success<IEnumerable<GeyRoleListQueryResponse>>(rolesMapper , "Success Get All Item");
        }

        public async Task<Response<GetUserWithRolesDto>> Handle(GetUserWithRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.id);
            if (user == null) return NotFound<GetUserWithRolesDto>();

            var roleUser = await _authorizationServices.GetUserWithRolesAsync(user);
            if (roleUser == null) return NotFound<GetUserWithRolesDto>();

            return Success<GetUserWithRolesDto>(roleUser);
        }

        #endregion
    }
}
