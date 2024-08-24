using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Moudles
{
    public class AddStudentCommand : IRequest<Response<string>>
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int  DepartmentId { get; set; }
    }
}
