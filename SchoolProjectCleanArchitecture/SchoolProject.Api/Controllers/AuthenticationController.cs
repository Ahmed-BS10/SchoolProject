using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commmand.Models;
using SchoolProject.Core.Features.Authentication.Query.Modles;
using SchoolProject.Core.Features.Authorization.Query.Modle;
using SchoolProject.Infrastrcture.Seeder;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
    
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Authentication.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }
        [HttpGet(Authentication.ConfirmResetPassword)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmEmailQuery query)
        {
            var response = await _mediator.Send(query);
            return NewResult(response);
        }

        [HttpPost(Authentication.SignIn)]
        public async Task<IActionResult> SignIn( SignCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Authentication.SendResetPasswordCode)]
        public async Task<IActionResult> SendRestEmail(string email)
        {
            var response = await _mediator.Send(new SendResetPasswordCodeCommand(email));
            return NewResult(response);
        }
        [HttpPost(Authentication.UpdatePassword)]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

       
    }
}
