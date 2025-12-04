using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllUserLeaveAllocationsWithDetails
{
    public class GetAllUserLeaveAllocationsWithDetailsQueryHandler : IRequestHandler<GetAllUserLeaveAllocationsWithDetailsQuery, IReadOnlyList<UserLeaveAllocationsWithDetailsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUserLeaveAllocationsWithDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyList<UserLeaveAllocationsWithDetailsDto>> Handle(GetAllUserLeaveAllocationsWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.GetAllUserLeaveAllocationsWithDetails(request.UserId);

            var leaveAllocationDto = _mapper.Map<IReadOnlyList<UserLeaveAllocationsWithDetailsDto>>(leaveAllocation);

            return leaveAllocationDto;
        }
    }
}
