using MediatR;
using SchoolProject.Core.Features.Users.Responses;
using SchoolProject.Core.Wapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Users.Query.Moudles
{
    public class GetUserPaginationListQuery : IRequest<PaginatedResult<GetUserPaginationListResponse>>
    {
        public int Pagnumber { get; set; }
        public int Size { get; set; }
    }
}
