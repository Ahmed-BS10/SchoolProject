namespace SchoolProject.Core.Features.Students.Responses
{
    public class GetStudentWithIncludeSingleResponse
    {

        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? NameDepartment { get; set; }

    }
}
