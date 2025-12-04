using HR.Management.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public int LeaveTypeId { get; set; }
        public int NumberOfDays { get; set; }
        public int Period { get; set; }
    }
}
