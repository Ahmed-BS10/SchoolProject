using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authorization.Respones;

namespace SchoolProject.Core.Mapping.Role;

public partial class RoleProfile 
{
    public void GetRoleListQueryMapping()
    {
        CreateMap<IdentityRole, GeyRoleListQueryResponse>();
        //.ForMember(dest => dest.Id , opt => opt.MapFrom(src => src.))
    }
}