using HR.Management.Application.Contracts.Persistance;
using HR.Management.Domain;
using HR.Management.Persistance.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace HR.Management.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }
        public async Task AddAllocations(IList<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
        }

        public async Task<bool> IsAllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                        && q.LeaveTypeId == leaveTypeId
                                        && q.Period == period);
        }

        public async Task<IReadOnlyList<LeaveAllocation>> GetAllLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _context.LeaveAllocations
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leaveAllocations;
        }

        public async Task<IReadOnlyList<LeaveAllocation>> GetAllUserLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationByIdWithDetails(int id)
        {
            var leaveAllocation = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation!;
        }

        public async Task<LeaveAllocation> GetUserAllocationsByLeaveTypeId(string userId, int leaveTypeId)
        {
            var leaveAllocation = await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                        && q.LeaveTypeId == leaveTypeId);
            return leaveAllocation!;
        }
    }
}
