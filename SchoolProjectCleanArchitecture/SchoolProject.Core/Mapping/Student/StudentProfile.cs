using AutoMapper;

namespace SchoolProject.Core.Mapping
{
    public partial class StudentProfile : Profile
    {
       public StudentProfile()
        {
            GetStudentListQueryMapping();
            GetStudentSingleQueryMapping();
            GetStudentByidQueryMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
           // GetStudentPaginateListQueryMapping();

        }
    }
}
