using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.DTO;
using SchoolProject.Data.Entities.Identity;
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
        Task<IdentityRole> GetRoleByIdAsync(string Id);
        Task<IEnumerable<IdentityRole>> GetRoleList();
        Task<string> AddRoleAsyncAsync(string RoleName);
        Task <bool> IsRoleExistByNameAsync(string RoleName);
        Task <bool> IsRoleExistByIdAsync(string id);
        Task<string> EditRoleAsync(string id, string name);
        Task<string> DeleteRoleAsync(string id);
        Task<GetUserWithRolesDto> GetUserWithRolesAsync(ApplicationUser user);
    }
}
