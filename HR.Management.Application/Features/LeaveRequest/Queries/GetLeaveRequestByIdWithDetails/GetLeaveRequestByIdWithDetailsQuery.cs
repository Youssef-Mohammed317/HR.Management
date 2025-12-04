using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestByIdWithDetails
{
    public class GetLeaveRequestByIdWithDetailsQuery : IRequest<LeaveRequestWithDetailsDto>
    {
        public int Id { get; set; }
    }
}
