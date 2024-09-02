using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.Abstracts;
using SchoolProject.Services.Implementions;

namespace SchoolProject.Services
{
    public static class ModuleServicesDependencies
    {
        public static IServiceCollection AddServiesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentServices, StudnetServices>();
            services.AddTransient<IDepartmentServices, DepartmnetServices>();
            services.AddTransient<IAuthenticationServices, AuthenticationServices>();
            services.AddTransient<IAuthorizationServices, AuthorizationServices>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IInstructorService, InstructorService>();

            services.AddTransient<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            return services;
        }

    }
}
