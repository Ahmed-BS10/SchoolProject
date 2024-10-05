using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Instructor.Command.Modlue;
using SchoolProject.Core.Features.Instructor.Query.Modlue;
using static SchoolProject.Data.AppMetaData.Route;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : AppControllerBase
    {
        public InstructorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost(InstructorRouting.Create)]
        public async Task<IActionResult> Add(AddInstructorCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);

        }

        [HttpDelete(InstructorRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteInstructorCommand(id));
            return NewResult(response);
        }


        [HttpGet(InstructorRouting.List)]
        public async Task<IActionResult> GetLIst()
        {
            var response = await _mediator.Send(new GetInstructorListQuery());
            return NewResult(response);
        }


        [HttpPut(InstructorRouting.Edit)]
        public async Task<IActionResult> Edit(EditInstrctorCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
