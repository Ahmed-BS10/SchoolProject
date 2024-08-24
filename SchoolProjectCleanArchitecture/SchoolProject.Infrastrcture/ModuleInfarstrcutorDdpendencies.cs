using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastrcture.Abstracts;
using SchoolProject.Infrastrcture.Repositories;

namespace SchoolProject.Infrastrcture
{
    public static class ModuleInfarstrcutorDdpendencies
    {
        public static IServiceCollection AddInfarstrctureDependincies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository , StudentRepository>();
            services.AddTransient<IDepartmentRepoistory, DepartmentRepository>();
            return services;
        }
    }
}
