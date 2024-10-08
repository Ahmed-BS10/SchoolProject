﻿using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commmand.Models
{
    public class SignCommand : IRequest<Response<string>>
    {
        
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
