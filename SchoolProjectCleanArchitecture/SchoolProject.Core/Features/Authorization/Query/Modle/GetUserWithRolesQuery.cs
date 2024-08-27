﻿using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Respones;
using SchoolProject.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Query.Modle
{
    public class GetUserWithRolesQuery : IRequest<Response<GetUserWithRolesDto>>
    {
        public string id {  get; set; }

        public GetUserWithRolesQuery(string id)
        {
            this.id=id;
        }
    }
}
