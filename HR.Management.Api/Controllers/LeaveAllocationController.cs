
using HR.Management.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.Management.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocationsWithDetails;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetAllUserLeaveAllocationsWithDetails;
using HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationByIdWithDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/LeaveAllocation
    [HttpGet]
    public async Task<IActionResult> GetAllLeaveAllocationWithDetails(bool isLoggedInUser = false)
    {
        var leaveAllocations = await _mediator.Send(new GetAllLeaveAllocationsWithDetailsQuery());
        return Ok(leaveAllocations);
    }

    // GET api/LeaveAllocation/5
    [HttpGet("{id:alpha}")]
    public async Task<IActionResult> GetAllUserLeaveAllocationWithDetails([FromRoute] string id)
    {
        var leaveAllocation = await _mediator.Send(new GetAllUserLeaveAllocationsWithDetailsQuery { UserId = id });
        return Ok(leaveAllocation);
    }

    // GET api/LeaveAllocation/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetLeaveAllocationByIdWithDetails([FromRoute] int id)
    {
        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationByIdWithDetailsQuery { Id = id });
        return Ok(leaveAllocation);
    }

    // POST api/LeaveAllocation
    [HttpPost]
    public async Task<IActionResult> Create(CreateLeaveAllocationCommand createLeaveAllocationCommand)
    {
        var response = await _mediator.Send(createLeaveAllocationCommand);
        return CreatedAtAction(nameof(GetLeaveAllocationByIdWithDetails), new { id = response });
    }

    // PUT api/LeaveAllocation/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateLeaveAllocationCommand updateLeaveAllocationCommand)
    {
        var response = await _mediator.Send(updateLeaveAllocationCommand);
        return CreatedAtAction(nameof(GetLeaveAllocationByIdWithDetails), new { id = response });
    }

    // DELETE api/LeaveAllocation/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
        return NoContent();
    }
}