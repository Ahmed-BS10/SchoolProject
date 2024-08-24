using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.Abstracts;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.InfarstrctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastrcture.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student> ,IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }
        #endregion

        #region Handles Funcations
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _students.Include(d => d.Department).ToListAsync();
        }
        #endregion

    }
}
