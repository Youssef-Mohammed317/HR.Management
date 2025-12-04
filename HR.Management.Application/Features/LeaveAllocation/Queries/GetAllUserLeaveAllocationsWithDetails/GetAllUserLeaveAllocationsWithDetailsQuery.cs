using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllUserLeaveAllocationsWithDetails
{
    public class GetAllUserLeaveAllocationsWithDetailsQuery : IRequest<IReadOnlyList<UserLeaveAllocationsWithDetailsDto>>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
