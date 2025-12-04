using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<int> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invaild Leave Allocation", validationResult);
            }

            var leaveAllocationEntity = await _unitOfWork.LeaveAllocationRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, leaveAllocationEntity);

            await _unitOfWork.LeaveAllocationRepository.UpdateAsync(leaveAllocationEntity);

            await _unitOfWork.SaveChangesAsync();

            return leaveAllocationEntity.Id;
        }
    }
}
