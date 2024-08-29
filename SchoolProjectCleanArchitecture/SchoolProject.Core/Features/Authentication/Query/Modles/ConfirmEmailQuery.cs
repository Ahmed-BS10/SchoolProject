using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Query.Modles
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
