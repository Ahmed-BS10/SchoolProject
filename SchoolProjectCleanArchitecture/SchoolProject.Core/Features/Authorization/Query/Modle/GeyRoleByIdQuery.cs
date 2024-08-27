using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Query.Modle
{
    public class GeyRoleByIdQuery : IRequest<Response<GeyRoleByIdQueryResponse>>
    {
        public string Id { get; set; }

        public GeyRoleByIdQuery(string id)
        {
            Id=id;
        }
    }
}
