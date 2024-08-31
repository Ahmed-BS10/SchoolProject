using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commmand.Models
{
    public class SendResetPasswordCodeCommand : IRequest<Response<string>>
    {
        public SendResetPasswordCodeCommand(string email)
        {
            Email=email;
        }

        public string Email { get; set; }
    }
}
