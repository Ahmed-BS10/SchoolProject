using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Departments.Query.Models;

namespace SchoolProject.Api.Controllers
{
   
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id) {

            var response = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return NewResult(response);
        }
    }
}
