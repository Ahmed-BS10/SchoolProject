using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.InfarstrctureBases;

public class SubjectsRepository : GenericRepositoryAsync<Subjects>, ISubjectsRepoistory
{
    #region Fields

    private readonly DbSet<Subjects> _subjects;

    #endregion

    #region Constructors
    public SubjectsRepository(ApplicationDbContext context) : base(context)
    {
        _subjects = context.Set<Subjects>();
    }
    #endregion

    #region Handles Funcations

    #endregion

}