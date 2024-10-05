using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructor.Command.Modlue;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructor.Command.Handler
{
    public class InstructorCommandHandler : ResponseHandler, IRequestHandler<AddInstructorCommand, Response<string>>
                                                            ,IRequestHandler<DeleteInstructorCommand , Response<string>>
                                                            ,IRequestHandler<EditInstrctorCommand, Response<string>>

    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        #endregion
        #region Constructors
        public InstructorCommandHandler(
                                        IMapper mapper,
                                        IInstructorService instructorService) 
        {
            _instructorService = instructorService;
            _mapper = mapper;
          
        }


        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Data.Entities.Instrctor>(request);
            var result = await _instructorService.AddInstructorAsync(instructor, request.Image);

            return result switch
            {
                "NoImage" => BadRequest<string>("NoImage"),
                "FailedToUploadImage" => BadRequest<string>(),
                "FailedToAddInstructor" => BadRequest<string>(),
                _ => Success("")
            };
        }

        public async Task<Response<string>> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var ins = await _instructorService.DeleteInstructorAsync(request.Id);
            if (ins == "Success") return Deleted<string>();
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditInstrctorCommand request, CancellationToken cancellationToken)
        {
            var insrtuctorMapper = _mapper.Map<Instrctor>(request);
            var result = await _instructorService.EditInstructorAsync(insrtuctorMapper);
            if (result == "Exist") return UnprocessableEntity<string>("Not Id Is There");
            return Success<string>("Edit Success", insrtuctorMapper);
        }
        #endregion
    }
}
