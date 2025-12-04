using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Queries.GetLeaveRequestByIdWithDetails
{
    public class GetLeaveRequestByIdWithDetailsQueryHandler : IRequestHandler<GetLeaveRequestByIdWithDetailsQuery, LeaveRequestWithDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLeaveRequestByIdWithDetailsQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<LeaveRequestWithDetailsDto> Handle(GetLeaveRequestByIdWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveRequestEntity = await _unitOfWork.LeaveRequestRepository.GetLeaveRequestByIdWithDetails(request.Id);

            if (leaveRequestEntity == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }

            var leaveRequest = _mapper.Map<LeaveRequestWithDetailsDto>(leaveRequestEntity);


            // Add Employee details as needed

            return leaveRequest;
        }
    }
}
