using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstracts
{
    public interface IAuthorizationServices
    {
        Task<string> AddRoleAsync(string RoleName);

       Task <bool> IsRoleExist(string RoleName);
        Task<string> EditRoleAsync(string id, string name);
    }
}
