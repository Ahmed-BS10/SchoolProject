using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

public interface IDepartmentServices
{
   Task<Department> GetDepartmentById(int id);
   Task<bool> IsDeparment(int id);

}
