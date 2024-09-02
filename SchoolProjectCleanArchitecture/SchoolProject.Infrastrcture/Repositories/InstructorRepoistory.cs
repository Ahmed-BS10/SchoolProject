using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.InfarstrctureBases;

public class InstructorRepoistory : GenericRepositoryAsync<Instructor>, IInstructorRepoistory
{
    #region Fields

    private readonly DbSet<Instructor> _instructor;

    #endregion

    #region Constructors
    public InstructorRepoistory(ApplicationDbContext context) : base(context)
    {
        _instructor = context.Set<Instructor>();
    }
    #endregion

    #region Handles Funcations

    #endregion

}
