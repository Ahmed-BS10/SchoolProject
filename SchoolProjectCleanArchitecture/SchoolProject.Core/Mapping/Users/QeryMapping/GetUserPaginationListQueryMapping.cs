using SchoolProject.Core.Features.Users.Responses;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserPaginationListQueryMapping()
        {
            CreateMap<ApplicationUser, GetUserPaginationListResponse>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber));

        }
    }
}
