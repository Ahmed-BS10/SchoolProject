using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Auth
{
    public interface IAuthenticationServices 
    {
        Task<JWTAuthResult> CreateTokenAsync(ApplicationUser applicationUser);
    }
}
