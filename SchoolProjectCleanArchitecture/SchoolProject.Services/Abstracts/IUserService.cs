using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Services.Abstracts;
public interface IUserService
{
    Task<string> AddUserAsync(ApplicationUser user, string password);
}

