using HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationByIdWithDetails
{
    public class LeaveAllocationByIdWithDetailsDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveTypeDto? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}