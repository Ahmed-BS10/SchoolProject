using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Responses
{
    public class GetDepartmentByIdResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }


        public List<StudentResponse>? Students { get; set; }
        public List<InstructorResponse>? Instructors { get; set; }
        public List<SubjectResponse>? Subjects { get; set; }


        public class StudentResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        public class InstructorResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        
        public class SubjectResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
