using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypesQueryHandler : IRequestHandler<GetAllLeaveTypesQuery, IReadOnlyList<LeaveTypeDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllLeaveTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyList<LeaveTypeDto>> Handle(GetAllLeaveTypesQuery request, CancellationToken cancellationToken)
        {

            var leaveTypes = await _unitOfWork.LeaveTypeRepository.GetAllAsync();

            var leaveTypeDtos = _mapper.Map<IReadOnlyList<LeaveTypeDto>>(leaveTypes);

            return leaveTypeDtos;

        }
    }
}
