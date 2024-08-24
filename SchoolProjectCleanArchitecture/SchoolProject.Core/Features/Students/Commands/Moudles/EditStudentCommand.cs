using MediatR;
using SchoolProject.Core.Bases;
using System.ComponentModel.DataAnnotations;

public class EditStudentCommand : IRequest<Response<string>>
{
   
    public int StudID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int DepartmentId { get; set; }
}
