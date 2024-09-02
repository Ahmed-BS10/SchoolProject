using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructor.Command.Modlue;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructor.Command.Handler
{
    public class InstructorCommandHandler : ResponseHandler, IRequestHandler<AddInstructorCommand, Response<string>>
    {

        #region Fileds
        private readonly IMapper _mapper;


        private readonly IInstructorService _instructorService;
        #endregion
        #region Constructors

        public InstructorCommandHandler(IMapper mapper, IInstructorService instructorService)
        {
            _mapper=mapper;
            _instructorService=instructorService;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Data.Entities.Instructor>(request);
            var result = await _instructorService.AddInstructorAsync(instructor, request.Image);

            return result switch
            {
                "NoImage" => BadRequest<string>("NoImage"),
                "FailedToUploadImage" => BadRequest<string>("FailedToUploadImage"),
                "FailedToAddInstructor" => BadRequest<string>("FailedToAddInstructor"),
                _ => Success("")
            };
        }
        #endregion
    }
}
