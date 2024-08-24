using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Users.Command.Modle
{
    public  class AddUserCommand : IRequest<Response<string>>
    {
        [Required]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
    }
}
