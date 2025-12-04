
using HR.Management.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HR.Management.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using HR.Management.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.Management.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using HR.Management.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequestsWithDetails;
using HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestByIdWithDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/LeaveRequest
        [HttpGet]
        public async Task<IActionResult> GetAllLeaveRequests(bool isLoggedInUser = false)
        {
            var leaveRequests = await _mediator.Send(new GetAllLeaveRequestWithDetialsQuery());
            return Ok(leaveRequests);
        }

        // GET api/LeaveRequest/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLeaveRequestByIdWithDetails([FromRoute] int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestByIdWithDetailsQuery { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/LeaveRequest
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLeaveRequestCommand createLeaveRequest)
        {
            var response = await _mediator.Send(createLeaveRequest);
            return CreatedAtAction(nameof(GetLeaveRequestByIdWithDetails), new { id = response });
        }

        // PUT api/LeaveRequest/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLeaveRequestCommand updateLeaveRequest)
        {
            var response = await _mediator.Send(updateLeaveRequest);
            return CreatedAtAction(nameof(GetLeaveRequestByIdWithDetails), new { id = response });
        }

        // PUT api/LeaveRequest/CancelRequest
        [HttpPut]
        public async Task<IActionResult> CancelRequest([FromBody] CancelLeaveRequestCommand cancelLeaveRequest)
        {
            await _mediator.Send(cancelLeaveRequest);
            return NoContent();
        }

        // PUT api/LeaveRequest/UpdateApproval
        [HttpPut]
        [Route("UpdateApproval")]
        public async Task<IActionResult> UpdateApproval([FromBody] ChangeLeaveRequestApprovalCommand updateApprovalRequest)
        {
            await _mediator.Send(updateApprovalRequest);
            return NoContent();
        }

        // DELETE api/LeaveRequest/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
