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
        Task<string> AddInstructorAsync(Instructor instructor, IFormFile Image);
        //Task<IReadOnlyList<Instructor>> GetAllInstructorsAsync();
        //Task<Instructor?> GetInstructorByIdAsync(int id);
    }
}
