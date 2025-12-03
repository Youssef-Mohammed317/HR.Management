using HR.Management.Domain;

namespace HR.Management.Application.Contracts.Persistance
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetAllLeaveRequestsWithDetails();
        Task<List<LeaveRequest>> GetAllUserLeaveRequestsWithDetails(string userId);
        Task<LeaveRequest> GetLeaveRequestByIdWithDetails(int id);
    }
}
