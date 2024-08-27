using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commmand.Models;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Core.Features.Authorization.Query.Modle;
using SchoolProject.Core.Features.Authorization.Respones;
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
    {

        #region Fields
        private readonly IAuthorizationServices _authorizationServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constrctuor(s)
        public RoleQueryHandler(IAuthorizationServices authorizationServices, IMapper mapper)
        {
            _authorizationServices=authorizationServices;
            _mapper=mapper;
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
        #endregion
    }
}
