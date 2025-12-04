using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationByIdWithDetails
{
    public class GetLeaveAllocationByIdWithDetailsQueryHandler : IRequestHandler<GetLeaveAllocationByIdWithDetailsQuery, LeaveAllocationByIdWithDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLeaveAllocationByIdWithDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<LeaveAllocationByIdWithDetailsDto> Handle(GetLeaveAllocationByIdWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocationEntity = await _unitOfWork.LeaveAllocationRepository.GetLeaveAllocationByIdWithDetails(request.Id);
            if (leaveAllocationEntity == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            }
            var leaveAllocationDto = _mapper.Map<LeaveAllocationByIdWithDetailsDto>(leaveAllocationEntity);
            return leaveAllocationDto;
        }
    }
}
