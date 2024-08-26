using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class AuthorizationController : AppControllerBase
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(AuthorizationRouting.AddRole)]
        public async Task<IActionResult> AddRole(string roleName)
        {
            var resonse = await _mediator.Send(new AddRoleCommand(roleName));
            return NewResult(resonse);
        }
    }
}
