using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Query.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public GetDepartmentByIdQuery(int id)
        {
            this.Id = id;
        }
        public int Id;
    }
}
