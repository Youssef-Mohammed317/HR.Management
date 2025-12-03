using HR.Management.Application.Contracts.Persistance;
using HR.Management.Domain;
using HR.Management.Persistance.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            var isExist = await _context.Set<LeaveType>().AnyAsync(e => e.Name.ToLower() == name.ToLower());
            return !isExist;
        }

        public async Task<bool> IsLeaveTypeUnique(string name, int excludeId)
        {
            var isExist = await _context.Set<LeaveType>()
                .AnyAsync(e => e.Name.ToLower() == name.ToLower() && e.Id != excludeId);
            return !isExist;
        }
    }
}
