using SchoolProject.Core.Features.Instructor.Response;
using SchoolProject.Core.Features.Students.Commands.Moudles;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
       public void GetListInstructorQueryMapper()
        {
            CreateMap<Instrctor, GetListInstructorQueryResponse>();
               



        }
    }
}
