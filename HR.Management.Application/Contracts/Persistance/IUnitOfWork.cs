using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Contracts.Persistance
{
    public interface IUnitOfWork
    {
        ILeaveTypeRepository LeaveTypeRepository { get; }
        ILeaveAllocationRepository LeaveAllocationRepository { get; }
        ILeaveRequestRepository LeaveRequestRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
