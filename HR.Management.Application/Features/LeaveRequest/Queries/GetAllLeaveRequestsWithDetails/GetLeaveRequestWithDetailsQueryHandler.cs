using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetAllLeaveRequestsWithDetails
{
    public class GetLeaveRequestWithDetailsQueryHandler : IRequestHandler<GetAllLeaveRequestWithDetialsQuery, IReadOnlyList<LeaveRequestWithDetailsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLeaveRequestWithDetailsQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<LeaveRequestWithDetailsDto>> Handle(GetAllLeaveRequestWithDetialsQuery request, CancellationToken cancellationToken)
        {

            // Check if it is logged in employee

            var leaveRequests = await _unitOfWork.LeaveRequestRepository.GetAllLeaveRequestsWithDetails();
            var requests = _mapper.Map<IReadOnlyList<LeaveRequestWithDetailsDto>>(leaveRequests);


            // Fill requests with employee information

            return requests;


        }
    }
}
