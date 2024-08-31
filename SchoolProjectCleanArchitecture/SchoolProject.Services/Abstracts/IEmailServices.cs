using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface IEmailServices
    {
        Task<string> SendEmailAsync(string email, string subject, string body, IList<IFormFile> formFiles = null);
        Task<string> SendEmailAsync(string email, string message, string? reason);



    }
}
