using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocationsWithDetails
{
    public class GetAllLeaveAllocationsWithDetailsDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveTypeDto? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public string UserId { get; set; } = string.Empty;
    }
}
