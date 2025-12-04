using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequestsWithDetails
{
    public class GetAllLeaveRequestWithDetialsQuery : IRequest<IReadOnlyList<LeaveRequestWithDetailsDto>>
    {
    }
}
