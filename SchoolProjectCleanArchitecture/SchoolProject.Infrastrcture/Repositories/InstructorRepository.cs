using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.InfarstrctureBases;

public class InstructorRepository : GenericRepositoryAsync<Instructor>, InstructorRepoistory
{
    #region Fields

    private readonly DbSet<Instructor> _instructor;

    #endregion

    #region Constructors
    public InstructorRepository(ApplicationDbContext context) : base(context)
    {
        _instructor = context.Set<Instructor>();
    }
    #endregion

    #region Handles Funcations

    #endregion

}
