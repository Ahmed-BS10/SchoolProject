using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructor.Query.Modlue;
using SchoolProject.Core.Features.Instructor.Response;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Responses;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructor.Query.Handler
{
    public class InstructorQueryHandler : ResponseHandler, IRequestHandler<GetInstructorListQuery, Response<List<GetListInstructorQueryResponse>>>
    {

        #region Fileds
        private readonly IInstructorService _instructorService;
        private readonly IMapper _imapper;
        #endregion

        #region Constructors
        public InstructorQueryHandler(IInstructorService instructorService, IMapper imapper)
        {
            _instructorService=instructorService;
            _imapper=imapper;
        }
        #endregion

        #region Handler Funcation

        public async Task<Response<List<GetListInstructorQueryResponse>>> Handle(GetInstructorListQuery request, CancellationToken cancellationToken)
        {
            var instructorList = await _instructorService.GetInstructorListAsync();
            var instructorListMapper = _imapper.Map<List<GetListInstructorQueryResponse>>(instructorList);
            if (instructorListMapper == null) return NotFound<List<GetListInstructorQueryResponse>>();
            return Success(instructorListMapper);
        }

        #endregion
    }
}
