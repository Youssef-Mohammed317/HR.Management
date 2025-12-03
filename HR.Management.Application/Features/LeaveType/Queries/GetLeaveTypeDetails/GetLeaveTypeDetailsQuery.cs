using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQuery : IRequest<LeaveTypeDetailsDto>
    {
        public int Id { get; set; }
    }
}
