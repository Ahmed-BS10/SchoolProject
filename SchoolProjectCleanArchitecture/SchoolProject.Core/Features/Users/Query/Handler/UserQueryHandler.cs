using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Query.Moudles;
using SchoolProject.Core.Features.Users.Responses;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Users.Query.Handler
{
    public class UserQueryHandler : ResponseHandler
                                   ,IRequestHandler<GetUserPaginationListQuery, PaginatedResult<GetUserPaginationListResponse>>
                                   ,IRequestHandler<GetUserByIdQuery , Response<GetUserByIdResponse>>
    {

        #region Field
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;


        #endregion

        #region Constrcutor(s)
        public UserQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager=userManager;
            _mapper=mapper;
        }



        #endregion

        #region Funcation Handler
        public Task<PaginatedResult<GetUserPaginationListResponse>> Handle(GetUserPaginationListQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var usersMapper = _mapper.ProjectTo<GetUserPaginationListResponse>(users);
            return usersMapper.ToPaginateListAsync(request.Pagnumber, request.Size);
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) return NotFound<GetUserByIdResponse>();
            var userMapper = _mapper.Map<GetUserByIdResponse>(user);
            return Success(userMapper);
        }
        #endregion
    }
}
