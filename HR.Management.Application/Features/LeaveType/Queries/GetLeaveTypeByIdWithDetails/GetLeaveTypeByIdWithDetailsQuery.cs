using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeByIdWithDetails
{
    public class GetLeaveTypeByIdWithDetailsQuery : IRequest<LeaveTypeDetailsDto>
    {
        public int Id { get; set; }
    }
}
