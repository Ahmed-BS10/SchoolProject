using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastrcture.Data;
using SchoolProject.Infrastrcture.Seeder;
using SchoolProject.Services.Abstracts;

namespace SchoolProject.Services.Implementions
{
    public class UserService : IUserService    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailServices _emailService;
        private readonly IUrlHelper _urlHelper;


        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, IEmailServices emailService, ApplicationDbContext dbContext, IUrlHelper urlHelper)
        {
            _userManager=userManager;
            _httpContextAccessor=httpContextAccessor;
            _emailService=emailService;
            _dbContext=dbContext;
            _urlHelper=urlHelper;
        }

        public async Task<string> AddUserAsync(ApplicationUser inputUser, string password)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var user = await _userManager.FindByEmailAsync(inputUser.Email);
                if (user != null)
                    return "EmailAlreadyExists";

                var UserByUserName = await _userManager.FindByNameAsync(inputUser.UserName);
                if (UserByUserName != null)
                    return "UserNameAlreadyExists";


                var createResult = await _userManager.CreateAsync(inputUser, password);

                if (!createResult.Succeeded)
                    return string.Join("; ", createResult.Errors.Select(e => e.Description));

                await _userManager.AddToRoleAsync(inputUser, Roles.User);

                // GenerateEmailConfirmationToken
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(inputUser);

                // Request Access
                var requestAccess = _httpContextAccessor.HttpContext.Request;
                var helper = _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = inputUser.Id, code = code });
                var returnUrl = requestAccess.Scheme + "://" + requestAccess.Host + helper;
                var message = $"To Confirm Email Click Link: <a href='{returnUrl}'>Confirm</a>";

                // Send Email
                var sendEmailResult = await _emailService.SendEmailAsync(inputUser.Email, message, "Confirming Email");

                if (sendEmailResult == "Failed")
                    return "FailedToSendEmail";

                transaction.Commit();
                return "Success";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return "Failed";
            }
        }
    }
}
