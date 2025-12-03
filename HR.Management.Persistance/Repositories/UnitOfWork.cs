using HR.Management.Application.Contracts.Persistance;
using HR.Management.Persistance.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HrDatabaseContext _context;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveRequestRepository _leaveRequestRepository;
        private ILeaveTypeRepository _leaveTypeRepository;
        public UnitOfWork(HrDatabaseContext context)
        {
            this._context = context;
        }

        public ILeaveTypeRepository LeaveTypeRepository
        {
            get
            {
                if (_leaveAllocationRepository == null)
                {
                    _leaveTypeRepository = new LeaveTypeRepository(_context);
                }
                return _leaveTypeRepository;
            }
        }

        public ILeaveAllocationRepository LeaveAllocationRepository
        {
            get
            {
                if (_leaveAllocationRepository == null)
                {
                    _leaveAllocationRepository = new LeaveAllocationRepository(_context);
                }
                return _leaveAllocationRepository;
            }
        }

        public ILeaveRequestRepository LeaveRequestRepository
        {
            get
            {
                if (_leaveRequestRepository == null)
                {
                    _leaveRequestRepository = new LeaveRequestRepository(_context);
                }
                return _leaveRequestRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
