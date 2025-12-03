using HR.Management.Domain;

namespace HR.Management.Application.Contracts.Persistance
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task AddAllocations(IList<LeaveAllocation> allocations);
        Task<IReadOnlyList<LeaveAllocation>> GetAllLeaveAllocationsWithDetails();
        Task<IReadOnlyList<LeaveAllocation>> GetAllUserLeaveAllocationsWithDetails(string userId);
        Task<LeaveAllocation> GetLeaveAllocationByIdWithDetails(int id);
        Task<LeaveAllocation> GetUserAllocationsByLeaveTypeId(string userId, int leaveTypeId);
        Task<bool> IsAllocationExists(string userId, int leaveTypeId, int period);
    }
}
