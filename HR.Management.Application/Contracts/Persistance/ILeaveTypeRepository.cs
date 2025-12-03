using HR.Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Contracts.Persistance
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
        Task<bool> IsLeaveTypeUnique(string name, int excludeId);
    }
}
