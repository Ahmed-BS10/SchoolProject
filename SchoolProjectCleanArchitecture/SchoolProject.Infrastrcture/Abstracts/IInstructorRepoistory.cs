using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.InfarstrctureBases;

public interface IInstructorRepoistory : IGenericRepositoryAsync<Instrctor>
{
    public Task<List<Instrctor>> GetInstructorListAsync();
}


