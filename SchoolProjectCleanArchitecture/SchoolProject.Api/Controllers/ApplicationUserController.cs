using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commmand.Models;
using SchoolProject.Core.Features.Users.Command.Modle;
using SchoolProject.Core.Features.Users.Command.Moudles;
using SchoolProject.Core.Features.Users.Query.Moudles;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
  
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        #region Constrcutor(s)
        public ApplicationUserController(IMediator mediator) : base(mediator)
        {
        }
        #endregion

        #region Endpoint


        [HttpGet(UserRouting.Pagination)]
        public async Task<IActionResult> PaginateList([FromQuery] GetUserPaginationListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(UserRouting.GetById)]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

        [HttpPost(UserRouting.Create)]
        public async Task<IActionResult> Create(AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(UserRouting.Edit)]
        public async Task<IActionResult> Edit(EditUserCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }



        [HttpPut(UserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword(ChangedPasswordUserCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(UserRouting.Delete)]
        public async Task<IActionResult> Delete(string id)
        {
            var respones = await _mediator.Send(new DeleteUserCommand(id));
            return NewResult(respones);
        }

        #endregion


    }
}
