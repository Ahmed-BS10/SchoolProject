using Azure;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementions
{
    public class AuthorizationServices : IAuthorizationServices
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        #endregion

        #region Constrctuor(s)
        public AuthorizationServices(RoleManager<IdentityRole> roleManager)
        {
            _roleManager=roleManager;
        }

        #endregion

        #region Funcation Handler   
        public async Task<string> AddRoleAsync(string RoleName)
        {
            var identityRole = new IdentityRole()
            {
                Name = RoleName
            };

            var result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
                return "Success";
            return "Failed";

        }

        public async Task<string> EditRoleAsync(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return "Not Found";

            role.Name = name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return "Success";


            var _erros = string.Join("-", result.Errors);
            return _erros;

        }

        public async Task<bool> IsRoleExist(string roleName)
        {
           //var role = await _roleManager.FindByNameAsync(roleName);
           // return role == null ? false : true;


            return await _roleManager.RoleExistsAsync(roleName);
        }


        #endregion
    }
}
