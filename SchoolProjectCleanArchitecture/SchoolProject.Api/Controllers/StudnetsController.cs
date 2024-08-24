using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Students.Commands.Moudles;
using SchoolProject.Core.Features.Students.Queries.Models;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class StudnetsController : AppControllerBase
    {
        #region Constrcutor(s)
        public StudnetsController(IMediator mediator) : base(mediator)
        {

        }
        #endregion


        #region EndPoint

        [AllowAnonymous]
        [HttpGet(StudentRouting.Pagination)]
        public async Task<IActionResult> GetPaginateList([FromQuery] GetStudentPaginateListQuery query)
        {

            var response = await _mediator.Send(query);
            if (response == null) return BadRequest("Help");
            return Ok(response);
        }

        [HttpGet(StudentRouting.List)]
        public async Task<IActionResult> GetStudnetList()
        {

            var response = await _mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }


        [HttpGet(StudentRouting.GetWithIncludeById)]
        public async Task<IActionResult> GetStudnetWithIncludeById(int Id)
        {
            var response = await _mediator.Send(new GetStudentIncludeByIdQuery(Id));
            return NewResult(response);
        }


        [HttpGet(StudentRouting.GetById)]
        public async Task<IActionResult> GetStudnetById(int Id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(Id));
            return NewResult(response);
        }


        [HttpPost(StudentRouting.Create)]
        public async Task<IActionResult> Create(AddStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);

        }
        #endregion


        [HttpPut(StudentRouting.Edit)]
        public async Task<IActionResult> Edit(EditStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }



        [HttpDelete(StudentRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }

    }
} 
