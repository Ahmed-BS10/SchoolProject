using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface ICurrentUserService
    {
        public Task<ApplicationUser> GetUserAsync();
        public string GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
