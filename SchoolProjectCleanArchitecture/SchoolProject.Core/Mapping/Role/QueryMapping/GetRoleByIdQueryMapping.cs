using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SchoolProject.Core.Features.Authorization.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Role
{
    public partial class RoleProfile
    {
        public void GetRoleByIdQueryMapping()
        {
            CreateMap<IdentityRole, GeyRoleByIdQueryResponse>();
                //.ForMember(dest => dest.Id , opt => opt.MapFrom(src => src.))
        }
    }
}
