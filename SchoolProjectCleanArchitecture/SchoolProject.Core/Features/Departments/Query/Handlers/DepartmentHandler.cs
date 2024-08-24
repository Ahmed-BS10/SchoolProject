using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Query.Models;
using SchoolProject.Core.Features.Departments.Responses;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Query.Handlers
{
    internal class DepartmentHandler : ResponseHandler
                                      ,IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {


        #region Fileds
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _imapper;
        #endregion

        #region Constructors
        public DepartmentHandler(IDepartmentServices departmentServices, IMapper imapper)
        {
            _departmentServices=departmentServices;
            _imapper=imapper;
        }


        #endregion

        #region Handler Duncation
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var depart = await _departmentServices.GetDepartmentById(request.Id);
            var depatMapper = _imapper.Map<GetDepartmentByIdResponse>(depart);
            if (depatMapper == null) return NotFound<GetDepartmentByIdResponse>();
            return Success(depatMapper);
        }
        #endregion
    }
}
