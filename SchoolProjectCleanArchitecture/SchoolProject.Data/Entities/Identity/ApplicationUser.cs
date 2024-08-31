using Microsoft.AspNetCore.Identity;
using SchoolManagment.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Countory { get; set; }

      
        public string ? Code { get; set; }
        public virtual ICollection<UserRefreshToken>? UserRefreshTokens { get; set; }

    }
}
