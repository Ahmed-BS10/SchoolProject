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
        public void GetStudentListQueryMapping()
        {
            CreateMap<Student, GetStudentLIstResponse>()
               .ForMember(dest => dest.NameDepartment, opt => opt.MapFrom(src => src.Department.DName));

        }
    }
}
