using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructor.Command.Modlue
{
    public class EditInstrctorCommand : IRequest<Response<string>> 
    {
        public int InstId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public double? Salary { get; set; }
        public int? DID { get; set; }
        public string? ImagePath { get; set; }
    }
}
