using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Users.Command.Moudles
{
    public class ChangedPasswordUserCommand : IRequest<Response<string>>
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string CurretPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmatPassword { get; set; }
    }
}
