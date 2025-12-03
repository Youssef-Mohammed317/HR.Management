using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<int> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeCommandValidator(_unitOfWork);

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave Type", validationResult);
            }

            var leaveTypeEntity = await _unitOfWork.LeaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypeEntity == null)
            {
                throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
            }

            _mapper.Map(request, leaveTypeEntity);

            await _unitOfWork.LeaveTypeRepository.UpdateAsync(leaveTypeEntity);

            await _unitOfWork.SaveChangesAsync();

            return leaveTypeEntity.Id;
        }
    }
}
