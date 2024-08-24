using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Students.Responses
{
    public class GetStudentPaginateLIstResponse
    {
        public GetStudentPaginateLIstResponse(int studID, string name, string address, string? nameDepartment)
        {
            StudID=studID;
            Name=name;
            Address=address;
            NameDepartment=nameDepartment;
        }

        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? NameDepartment { get; set; }

    }
}
