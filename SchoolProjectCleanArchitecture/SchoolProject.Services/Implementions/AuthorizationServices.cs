using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.DTO;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastrcture.Data;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constrctuor(s)
        public AuthorizationServices(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _roleManager=roleManager;
            _userManager=userManager;
            _context=context;
        }

        #endregion

        #region Funcation Handler   
        public async Task<string> AddRoleAsyncAsync(string RoleName)
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
        public async Task<string> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return "Not Found";

            var user = await _userManager.GetUsersInRoleAsync(role.Name);
            if (user != null) return "role Used";

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return "Success";

            var _erros = string.Join("-", result.Errors);
            return _erros;
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
        public async Task<string> EditUserRolesAsync(EditUserRolesDto request)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(request.Id);

                if (user == null)
                    return "UserIsNull";

                var userRole = await _userManager.GetRolesAsync(user);
                var resultDelete = await _userManager.RemoveFromRolesAsync(user, userRole);
                if (!resultDelete.Succeeded) return "FailedToRemoveOldRoles";

                var selectRoles = request.rolesUsers.Where(x => x.HasRole == true).Select(x=> x.RoleName);
                var resultAdd = await _userManager.AddToRolesAsync(user, selectRoles);
                if (!resultAdd.Succeeded) return "FailedToAddNewRoles";
                await transaction.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return "FailedToUpdateUserRoles";
            }

        }
        public async Task<IdentityRole> GetRoleByIdAsync(string Id)
        {
            
            var role = await _roleManager.FindByIdAsync(Id);
            return role;
        }
        public async Task<IEnumerable<IdentityRole>> GetRoleList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles == null) return null;

            return roles;
        }
        public async Task<GetUserWithRolesDto> GetUserWithRolesAsync(ApplicationUser user)
        {
            var respones = new GetUserWithRolesDto();
            var roles = new List<Roles>();

          
            var userRoles = await _userManager.GetRolesAsync(user);
            var rolesManager = await _roleManager.Roles.ToListAsync();

            foreach (var _role in rolesManager)
            {
                var role = new Roles()
                {
                    Id = _role.Id,
                    RoleName = _role.Name
                };

                if (userRoles.Contains(_role.Name))
                {
                    roles.Add(role);
                }
            }


            respones.Id = user.Id;
            respones.roles = roles;

            return respones;
        }
        public async Task<bool> IsRoleExistByIdAsync(string id)
        {
           var role = await _roleManager.FindByIdAsync(id);
            return role != null ? true : false;

            
        }
        public async Task<bool> IsRoleExistByNameAsync(string roleName)
        {
           //var role = await _roleManager.FindByNameAsync(roleName);
           // return role == null ? false : true;


            return await _roleManager.RoleExistsAsync(roleName);
        }

      
        #endregion
    }
}
