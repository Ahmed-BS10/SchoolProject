using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructor.Response;
using SchoolProject.Core.Features.Students.Responses;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructor.Query.Modlue
{
    public class GetInstructorListQuery : IRequest<Response<List<GetListInstructorQueryResponse>>>
    {

    }
}
