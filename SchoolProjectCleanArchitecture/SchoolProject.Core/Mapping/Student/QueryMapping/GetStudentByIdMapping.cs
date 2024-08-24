using SchoolProject.Core.Features.Students.Responses;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolProject.Core.Mapping
{
    public partial class StudentProfile
    {
        public void GetStudentByidQueryMapping()
        {
            CreateMap<Student, GetStudentSingleResponse>();

        }
    }
}