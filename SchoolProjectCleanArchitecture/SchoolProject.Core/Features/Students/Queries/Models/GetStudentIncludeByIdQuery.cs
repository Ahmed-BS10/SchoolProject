using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentIncludeByIdQuery : IRequest<Response<GetStudentWithIncludeSingleResponse>>
    {
        public int Id { get; set; }
        public GetStudentIncludeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
