using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Email.Command.Modle
{
    public class SendEmailCommand : IRequest<Response<string>>
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string? Body { get; set; }
        public IList<IFormFile>? formFiles { get; set; }
    }
}
