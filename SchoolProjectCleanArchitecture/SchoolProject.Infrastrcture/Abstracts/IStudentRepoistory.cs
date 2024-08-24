using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.InfarstrctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastrcture.Abstracts
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
       public Task <List<Student>> GetStudentListAsync();
    }
}
