using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Query.Modle
{
    public class ManagerUserClaimQuery : IRequest<Response<ManagerUserWithClaimDto>>
    {
        public string id { get; set; }

        public ManagerUserClaimQuery(string id)
        {
            this.id=id;
        }
    }
}
