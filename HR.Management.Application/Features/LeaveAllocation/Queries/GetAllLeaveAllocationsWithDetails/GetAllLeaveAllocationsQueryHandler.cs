using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocationsWithDetails
{
    public class GetAllLeaveAllocationsQueryHandler : IRequestHandler<GetAllLeaveAllocationsWithDetailsQuery, IReadOnlyList<GetAllLeaveAllocationsWithDetailsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllLeaveAllocationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<IReadOnlyList<GetAllLeaveAllocationsWithDetailsDto>> Handle(GetAllLeaveAllocationsWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _unitOfWork.LeaveAllocationRepository.GetAllLeaveAllocationsWithDetails();

            var leaveAllocationsDto = _mapper.Map<IReadOnlyList<GetAllLeaveAllocationsWithDetailsDto>>(leaveAllocations);

            return leaveAllocationsDto;
        }
    }
}
