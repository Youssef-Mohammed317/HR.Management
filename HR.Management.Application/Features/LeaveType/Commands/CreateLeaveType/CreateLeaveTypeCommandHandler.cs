using AutoMapper;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using MediatR;
using System;

namespace HR.Management.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            // Validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_unitOfWork);

            var validationResult = await validator.ValidateAsync(request);

            // If validation fails, throw an exception
            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave Type", validationResult);
            }

            // Mapping from command to domain entity
            var leaveTypeEntity = _mapper.Map<Domain.LeaveType>(request);

            // Persisting the new entity
            await _unitOfWork.LeaveTypeRepository.CreateAsync(leaveTypeEntity);
            await _unitOfWork.SaveChangesAsync();

            // Returning the identifier of the newly created entity
            return leaveTypeEntity.Id;
        }

    }
}
