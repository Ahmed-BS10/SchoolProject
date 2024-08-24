using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Responses;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentsQueryHandler : ResponseHandler
                                       ,IRequestHandler<GetStudentListQuery,Response<List<GetStudentLIstResponse>>>
                                       ,IRequestHandler<GetStudentIncludeByIdQuery, Response<GetStudentWithIncludeSingleResponse>>
                                       ,IRequestHandler<GetStudentByIdQuery , Response<GetStudentSingleResponse>>
                                       ,IRequestHandler<GetStudentPaginateListQuery ,PaginatedResult<GetStudentPaginateLIstResponse>>
    {
        #region Fileds
        private readonly IStudentServices _studentServices;
        private readonly IMapper _imapper;
        #endregion

        #region Constructors
        public StudentsQueryHandler(IStudentServices studentServices, IMapper imapper)
        {
            _studentServices=studentServices;
            _imapper=imapper;
        }
        #endregion

        #region Handler Funcation
        public async Task<Response<List<GetStudentLIstResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            
            var studentList =  await _studentServices.GetStudentListAsync();
            var studentListMapper = _imapper.Map<List<GetStudentLIstResponse>>(studentList);
            if (studentListMapper == null) return NotFound<List<GetStudentLIstResponse>>();
            return Success(studentListMapper);
        }

        public async Task<Response<GetStudentWithIncludeSingleResponse>> Handle(GetStudentIncludeByIdQuery request, CancellationToken cancellationToken)
        {
           var student = await _studentServices.GetStudentWithIncludeByIdAsync(request.Id);
           var studentMapper = _imapper.Map<GetStudentWithIncludeSingleResponse>(student);
            if (studentMapper == null) return NotFound<GetStudentWithIncludeSingleResponse>();
           return Success(studentMapper);
        }

        public async Task<Response<GetStudentSingleResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentServices.GetStudentByIdAsync(request.id);
            var studentMapper = _imapper.Map<GetStudentSingleResponse>(student);
            if(studentMapper == null) return NotFound<GetStudentSingleResponse>();
            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginateLIstResponse>> Handle(GetStudentPaginateListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student,GetStudentPaginateLIstResponse>> expression = e => new GetStudentPaginateLIstResponse(e.StudID , e.Name , e.Address ,e.Department.DName);
            // var student =  _studentServices.GetStudentPaginateList();

            enStudentOrderEnum enStudentOrderEnum = new enStudentOrderEnum();
            var student = _studentServices.FilterStudentPaginateListQueryable(enStudentOrderEnum, request.Search);

            var gg = await student.Select(expression).ToPaginateListAsync(request.PageNumber, request.PageSize);
            return gg;

        }




        #endregion


    }
}
