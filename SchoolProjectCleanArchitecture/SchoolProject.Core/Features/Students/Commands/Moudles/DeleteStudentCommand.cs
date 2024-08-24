using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Moudles
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public int id { get; set; }

        public DeleteStudentCommand(int id)
        {
            this.id=id;
        }
    }
}
