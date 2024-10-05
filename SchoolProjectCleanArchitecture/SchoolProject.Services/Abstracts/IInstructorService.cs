using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface IInstructorService
    {

        bool IsNameEnExist(string name);
        Task<bool> IsExist(int id);
        Task<List<Instrctor>> GetInstructorListAsync();
        Task<string> AddInstructorAsync(Instrctor instructor, IFormFile Image);
        Task<string> DeleteInstructorAsync(int id);
        Task<string> EditInstructorAsync(Instrctor instrctor);


        //Task<IReadOnlyList<Instructor>> GetAllInstructorsAsync();
        //Task<Instructor?> GetInstructorByIdAsync(int id);
    }
}
