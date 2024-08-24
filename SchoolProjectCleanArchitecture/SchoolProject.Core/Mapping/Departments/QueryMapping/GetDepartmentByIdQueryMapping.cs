using SchoolProject.Core.Features.Departments.Responses;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolProject.Core.Features.Departments.Responses.GetDepartmentByIdResponse;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdQueryMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.instructor.Name))

                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.instructors))
                .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects));


            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subjects.SubjectName));


            CreateMap<Instructor, InstructorResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InstId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


            CreateMap<Student, StudentResponse>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));



        }
    }
}
