using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Command.Modle
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public AddRoleCommand(string roleName)
        {
            RoleName=roleName;
        }

        [Required]
        public string RoleName { get; set; }
        
    }
}
