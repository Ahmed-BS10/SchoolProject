using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastrcture.Abstracts;

internal class DepartmnetServices : IDepartmentServices
{
    #region Fields
    private readonly IDepartmentRepoistory _departmentRepoistory;
    #endregion

    #region Constrcutor(s)
    public DepartmnetServices(IDepartmentRepoistory departmentRepoistory)
    {
        _departmentRepoistory=departmentRepoistory;
    }


    #endregion

    #region Handle Funcations
    public async Task<Department> GetDepartmentById(int id)
    {
     
       var depat =   _departmentRepoistory.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                .Include(s => s.Students)
                                                .Include(i => i.instructors)
                                                .Include(m => m.instructor)
                                                .Include(sd => sd.DepartmentSubjects).ThenInclude(sb => sb.Subjects)
                                                .FirstOrDefault();

        return depat;
    }

    public async Task<bool> IsDeparment(int id)
    {
        var depart =  _departmentRepoistory.GetTableNoTracking().Where(x => x.DID == id).FirstOrDefault();
        return  depart != null ? true : false;
    }
    #endregion

}