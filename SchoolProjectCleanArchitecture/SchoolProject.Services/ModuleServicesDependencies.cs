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
            return services;
        }

    }
}
