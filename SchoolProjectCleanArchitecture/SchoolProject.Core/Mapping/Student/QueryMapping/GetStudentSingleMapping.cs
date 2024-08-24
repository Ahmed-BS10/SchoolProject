using SchoolProject.Core.Features.Students.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping;

public partial class StudentProfile
{
    public void GetStudentSingleQueryMapping()
    {
        CreateMap<Student, GetStudentWithIncludeSingleResponse>()
            .ForMember(dest => dest.NameDepartment, opt => opt.MapFrom(src => src.Department.DName));
            
    }
}