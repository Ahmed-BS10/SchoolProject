using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Modle
{
    public class EditUserClaimCommand : ManagerUserWithClaimDto, IRequest<Response<string>>
    {
    }
}
