using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrastrcture.Seeder;
using System.Data;

namespace SchoolManagment.Infrastructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> _roleManager)
        {
            if (await _roleManager.Roles.CountAsync() == 0)
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));

                await _roleManager.CreateAsync(new IdentityRole(Roles.User));

            }
        }
    }
}
