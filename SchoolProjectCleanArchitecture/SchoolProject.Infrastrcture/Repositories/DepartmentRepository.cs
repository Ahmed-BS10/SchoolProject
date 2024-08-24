using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastrcture.Abstracts;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.InfarstrctureBases;

public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepoistory
{
    #region Fields

    private readonly DbSet<Department> _departments;

    #endregion

    #region Constructors
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
       _departments = context.Set<Department>();
    }
    #endregion

    #region Handles Funcations

    #endregion

}
