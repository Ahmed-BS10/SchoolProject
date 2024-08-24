using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Responses;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentPaginateListQuery : IRequest<PaginatedResult<GetStudentPaginateLIstResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public enStudentOrderEnum? orderBy { get; set; }
        public string? Search {  get; set; }
        
    }
}
