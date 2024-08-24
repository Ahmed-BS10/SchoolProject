using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface IStudentServices
    {
        Task<List<Student>> GetStudentListAsync();
        Task<Student> GetStudentWithIncludeByIdAsync(int Id);
        Task<Student> GetStudentByIdAsync(int Id);
        IQueryable<Student> GetStudentPaginateListQueryable();
        Task<string> AddStudentAsync(Student student);
        Task<string> EditStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int Id);
        IQueryable<Student> FilterStudentPaginateListQueryable(enStudentOrderEnum orderingStident , string search);

    }
}
