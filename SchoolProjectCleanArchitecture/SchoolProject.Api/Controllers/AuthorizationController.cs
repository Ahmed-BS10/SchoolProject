using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Infrastrcture.Seeder;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = Roles.Admin)]
    public class AuthorizationController : AppControllerBase
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(AuthorizationRouting.AddRole)]
        public async Task<IActionResult> Add(string roleName)
        {
            var resonse = await _mediator.Send(new AddRoleCommand(roleName));
            return NewResult(resonse);
        }


        [HttpPut(AuthorizationRouting.EditRole)]
        public async Task<IActionResult> Edit(EditRoleCommand command)
        {
            var resonse = await _mediator.Send(command);
            return NewResult(resonse);
        }
    }
}
