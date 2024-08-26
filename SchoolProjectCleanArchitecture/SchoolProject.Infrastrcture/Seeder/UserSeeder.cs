using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastrcture.Seeder;

namespace SchoolManagment.Infrastructure.Seeder
{
    public static class UserSeeder
    {

        public async static Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.Users.CountAsync() == 0)
            {

                var defaultuser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@project.com",
                    FullName = "schoolProject",
                    Countory = "Egypt",
                    PhoneNumber = "123456",
                    Address = "Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(defaultuser, "Aa@123.123");
                await userManager.AddToRoleAsync(defaultuser, Roles.Admin);
            }
        }
    }
}
