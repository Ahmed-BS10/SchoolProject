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

        [HttpGet(Authencation.GetList)]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GeyRoleListQuery());
            return NewResult(response);
        }

        [HttpGet(Authencation.GetById)]
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
