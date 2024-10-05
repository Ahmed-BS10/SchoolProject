using SchoolProject.Core.Features.Instructor.Command.Modlue;
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
        public void EditInstcutorCommandMapping()
        {
            CreateMap<EditInstrctorCommand, Instrctor>();
        }
    }
}
