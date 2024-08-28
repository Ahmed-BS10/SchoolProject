using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Modle;
using SchoolProject.Core.Features.Authorization.Query.Modle;
using SchoolProject.Infrastrcture.Seeder;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    //[Authorize(Roles = Roles.Admin)]
    public class AuthorizationController : AppControllerBase
    {
        public AuthorizationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPut("aa")]
        public async Task<IActionResult> EditUserClaims(EditUserClaimCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }


        [HttpGet(AuthorizationRouting.UserClaims)]
        public async Task<IActionResult> GetUserClaims(string id)
        {
            var response = await _mediator.Send( new ManagerUserClaimQuery(id));
            return NewResult(response);
        }

        [HttpPut(AuthorizationRouting.EditUserRoles)]
        public async Task<IActionResult> EditUserRoles([FromBody] EditUserRolesCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(AuthorizationRouting.GetUserWithRoles)]
        public async Task<IActionResult> GetUserWithRoles(string id)
        {
            var response = await _mediator.Send(new GetUserWithRolesQuery(id));
            return NewResult(response);
        }

        [HttpGet(AuthorizationRouting.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GeyRoleListQuery());
            return NewResult(response);
        }

        [HttpGet(AuthorizationRouting.GetById)]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _mediator.Send(new GeyRoleByIdQuery(id));
            return NewResult(response);
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

        [HttpDelete(AuthorizationRouting.DeleteRole)]
        public async Task<IActionResult> Delete(string id)
        {
            var resonse = await _mediator.Send(new DeleteRoleCommand(id));
            return NewResult(resonse);
        }


       
    }
}
