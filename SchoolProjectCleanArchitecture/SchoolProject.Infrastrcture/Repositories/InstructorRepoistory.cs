using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.InfarstrctureBases;

public class InstructorRepoistory : GenericRepositoryAsync<Instrctor>, IInstructorRepoistory
{
    #region Fields

    private readonly DbSet<Instrctor> _instructor;

    #endregion

    #region Constructors
    public InstructorRepoistory(ApplicationDbContext context) : base(context)
    {
        _instructor = context.Set<Instrctor>();
    }


    #endregion

    #region Handles Funcations
    public Task<List<Instrctor>> GetInstructorListAsync()
    {
       return _instructor.Include(x => x.department).ToListAsync();
    }
    #endregion

}
