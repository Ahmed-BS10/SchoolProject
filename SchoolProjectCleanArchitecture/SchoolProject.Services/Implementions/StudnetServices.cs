using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;
using SchoolProject.Infrastrcture.Abstracts;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementions
{
    internal class StudnetServices : IStudentServices
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constrcutor(s)
        public StudnetServices(IStudentRepository studentRepository)
        {
            _studentRepository=studentRepository;
        }
        #endregion

        #region Handle Funcations
        public async Task<List<Student>> GetStudentListAsync()
        {
           return await _studentRepository.GetStudentListAsync();
        }

        public async Task<Student> GetStudentWithIncludeByIdAsync(int Id)
        {
            var student = _studentRepository.GetTableNoTracking().Include(x => x.Department).Where(x => x.StudID.Equals(Id)).FirstOrDefault();
            if (student == null) return null;
            return student;
        }
        public async Task<Student> GetStudentByIdAsync(int Id)
        {
            var student = _studentRepository.GetTableNoTracking().Where(x => x.StudID.Equals(Id)).FirstOrDefault();
            if (student == null) return null;
            return student;
        }
        public async Task<string> AddStudentAsync(Student student)
        {
            var studentresponse = _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(student.Name)).FirstOrDefault();
            if (studentresponse is not null) return "Exist";
            await _studentRepository.AddAsync(student);
            return "Success";



        }

        public async Task<string> EditStudentAsync(Student student)
        {
            var studentresponse = await _studentRepository.GetTableNoTracking().Where(x => x.StudID == student.StudID).FirstOrDefaultAsync();
            if (studentresponse is null) return "Exist";
            await _studentRepository.UpdateAsync(student);
            return "Success";

        }

        public async Task<bool> DeleteStudentAsync(int Id)
        {
           var student =  _studentRepository.GetTableNoTracking().Where(x => x.StudID == Id).FirstOrDefault();
            if (student is null) return false;
            await _studentRepository.DeleteAsync(student);
            return true;
            
        }

       

        public IQueryable<Student> GetStudentPaginateListQueryable()
        {
            var student = _studentRepository.GetTableNoTracking().Include(d => d.Department);
            return student;
        }

        public IQueryable<Student> FilterStudentPaginateListQueryable(enStudentOrderEnum orderingStudent , string search)
        {
            var studentList = GetStudentPaginateListQueryable();
            if (search != null)
            {
                studentList =  studentList.Where(x => x.Name.Contains(search) || x.Address.Contains(search));
            }

            switch(orderingStudent)
            {
                case enStudentOrderEnum.StudID: return studentList = studentList.OrderBy(x => x.StudID);break;
                case enStudentOrderEnum.Name: return studentList = studentList.OrderBy(x => x.Name);break;
                case enStudentOrderEnum.Address: return studentList = studentList.OrderBy(x => x.Address);break;
                case enStudentOrderEnum.NameDepartment: return studentList = studentList.OrderBy(x => x.Department.DName);break;
                        
     

            }    
            return studentList;
        }
        #endregion

    }
}
