using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Core.Features.Email.Command.Modle;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Email.Command.Handler
{
    public class EmailCommandHandler : ResponseHandler , IRequestHandler<SendEmailCommand , Response<string>>
    {
        #region Fields
        private readonly IEmailServices _emailServices;
        #endregion

        #region Constrctuor(s)
        public EmailCommandHandler(IEmailServices emailServices)
        {
            _emailServices=emailServices;
        }
        #endregion

        #region Funcation Handler
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var sendedEmail = await _emailServices.SendEmailAsync(request.EmailTo, request.Subject, request.Body, request.formFiles);
            if (sendedEmail == null) return BadRequest<string>();

            return Success(sendedEmail);
        }
        #endregion
    }
}
