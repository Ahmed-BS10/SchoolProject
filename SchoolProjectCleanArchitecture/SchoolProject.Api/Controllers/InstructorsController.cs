using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Instructor.Command.Modlue;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : AppControllerBase
    {
        public InstructorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddInstructorCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);

        }
    }
}
