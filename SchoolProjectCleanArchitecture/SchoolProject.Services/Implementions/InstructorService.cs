using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementions
{
    public class InstructorService : IInstructorService
    {
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IInstructorRepoistory _instructorRepository;
        public InstructorService(IFileService fileService, IHttpContextAccessor httpContext , IInstructorRepoistory instructorRepository)
        {
            _fileService = fileService;
            _httpContext = httpContext;
            _instructorRepository=instructorRepository;
        }
        public bool IsNameEnExist(string name)
            => _instructorRepository.GetTableNoTracking().Any(x => x.Name == name);
       
        public async Task<string> AddInstructorAsync(Instrctor instructor, IFormFile image)
        {
            // Construct the base URL for the current request
            //var request = _httpContext.HttpContext.Request;
            //var baseUrl = $"{request.Scheme}://{request.Host}";

            // Upload the image file and get the image path
            string imagePath = null;
            if (image != null)
            {
               imagePath = await _fileService.UploadFileAsync("InstructorImages", image);

            }



            // Check if the image upload was successful
            if (imagePath == "NoImage" || imagePath == "FailedToUploadImage")
                return imagePath;

            try
            {
                // Set the image path for the instructor
              //  instructor.ImagePath = $"{baseUrl}{imagePath}";

                // Add the instructor to the repository
                await _instructorRepository.AddAsync(instructor);

                return "Success";
            }
            catch (Exception ex)
            {
             //   Log.Error("Failed To Add Instructor", ex.Message);

                return "FailedToAddInstructor";
            }
        }
        public async Task<bool> IsExist(int id)
            =>await _instructorRepository.GetTableNoTracking().AnyAsync(x => x.InstId == id);
        public async Task<string> DeleteInstructorAsync(int id)
        {
            var insructor =await _instructorRepository.GetTableNoTracking().Where(x => x.InstId == id).FirstOrDefaultAsync();
            if (insructor is not null)
            {
                await _instructorRepository.DeleteAsync(insructor);
                return "Success";
            }


            return "Failed";


        }
        public async Task<List<Instrctor>> GetInstructorListAsync()
        {
            var listInstructor = await _instructorRepository.GetInstructorListAsync();
            return listInstructor.ToList();
        }
        public async Task<string> EditInstructorAsync(Instrctor instrctor)
        {
            var instrctoresponse = await _instructorRepository.GetTableNoTracking().Where(x => x.InstId == instrctor.InstId).FirstOrDefaultAsync();

            if (instrctoresponse is null) return "Exist";
            await _instructorRepository.UpdateAsync(instrctor);
            return "Success";
        }
    }
}
