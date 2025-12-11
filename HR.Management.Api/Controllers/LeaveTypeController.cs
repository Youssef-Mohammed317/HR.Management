using HR.Management.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.Management.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.Management.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeByIdWithDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/LeaveType
        [HttpGet]
        public async Task<IActionResult> GetAllLeaveTypes()
        {
            var data = await _mediator.Send(new GetAllLeaveTypesQuery());
            return Ok(data);
        }

        // GET api/LeaveType/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLeaveTypeById([FromRoute] int id)
        {
            var data = await _mediator.Send(new GetLeaveTypeByIdWithDetailsQuery() { Id = id });
            return Ok(data);
        }

        // POST api/LeaveType
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeaveTypeCommand createLeaveTypeCommand)
        {
            var response = await _mediator.Send(createLeaveTypeCommand);
            return CreatedAtAction(nameof(GetLeaveTypeById), new { id = response });
        }

        // PUT api/LeaveType/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLeaveTypeCommand updateLeaveTypeCommand)
        {
            var response = await _mediator.Send(updateLeaveTypeCommand);
            return CreatedAtAction(nameof(GetLeaveTypeById), new { id = response });
        }

        // DELETE api/LeaveType/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand() { Id = id });

            return NoContent();
        }
    }
}
