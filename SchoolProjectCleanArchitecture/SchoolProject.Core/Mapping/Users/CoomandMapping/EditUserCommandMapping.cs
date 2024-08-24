﻿using SchoolProject.Core.Features.Users.Command.Modle;
using SchoolProject.Core.Features.Users.Command.Moudles;
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
        public void EditUserCommandMapping()
        {
            CreateMap<EditUserCommand, ApplicationUser>()
                 .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                 .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                 .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                 .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        }
    }
}