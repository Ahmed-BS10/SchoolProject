using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Role
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            GetRoleByIdQueryMapping();
            GetRoleListQueryMapping();
        }
    }
}
