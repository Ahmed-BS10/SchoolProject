using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Moudles;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentsCommandHandler : ResponseHandler, 
                                          IRequestHandler<AddStudentCommand,Response<string>>,
                                          IRequestHandler<EditStudentCommand, Response<string>>,
                                          IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Field
        private readonly IMapper _mapper;
        private readonly IStudentServices _studentServices;
        private readonly IDepartmentServices _departmentServices;
        // private readonly IStringLocalizer<SharedResource> stringLocalizer;
        #endregion

        #region Constrcutor(s)
        public StudentsCommandHandler(IMapper mapper, IStudentServices studentServices, IDepartmentServices departmentServices)
        {
            _mapper=mapper;
            _studentServices=studentServices;
            _departmentServices=departmentServices;
        }
        #endregion

        #region Handler Funcation
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            bool IsDepart = await _departmentServices.IsDeparment(request.DepartmentId);
            if(IsDepart)
            {
                var studentMapper = _mapper.Map<Student>(request);
                var result = await _studentServices.AddStudentAsync(studentMapper);
                if (result == "Exist") return UnprocessableEntity<string>("Name Is Exist");
                return Created<string>("Creaet Successed");
            }

            return UnprocessableEntity<string>("The Depart is not in the database ");

        }
        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentServices.EditStudentAsync(studentMapper);
            if (result == "Exist") return UnprocessableEntity<string>("Not Id Is There");
            return Success<string>("Edit Success", studentMapper);
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentServices.DeleteStudentAsync(request.id);
            if (student == true) return Deleted<string>();
            return BadRequest<string>();
        }
        #endregion

    }
}
