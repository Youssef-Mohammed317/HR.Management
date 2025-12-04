using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequestsWithDetails
{
    public class LeaveRequestWithDetailsDto
    {
        public int Id { get; set; }
        public string RequestingEmployeeId { get; set; } = string.Empty;
        public LeaveTypeDto? LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }
    }
}
