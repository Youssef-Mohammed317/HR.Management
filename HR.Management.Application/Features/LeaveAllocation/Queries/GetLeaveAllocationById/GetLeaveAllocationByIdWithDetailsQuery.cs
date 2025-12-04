using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationByIdWithDetails
{
    public class GetLeaveAllocationByIdWithDetailsQuery : IRequest<LeaveAllocationByIdWithDetailsDto>
    {
        public int Id { get; set; }
    }
}
