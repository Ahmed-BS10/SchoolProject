using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Modle
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public string id { get; set; }

        public DeleteRoleCommand(string id)
        {
            this.id=id;
        }
    }
}
