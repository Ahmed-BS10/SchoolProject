using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commmand.Models;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthencationController : AppControllerBase
    {
        public AuthencationController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost(Authencation.SignIn)]
        public async Task<IActionResult> SignIn( SignCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

    }
}
