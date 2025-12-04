using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocationsWithDetails
{
    public class GetAllLeaveAllocationsWithDetailsQuery : IRequest<IReadOnlyList<GetAllLeaveAllocationsWithDetailsDto>>
    {

    }
}
