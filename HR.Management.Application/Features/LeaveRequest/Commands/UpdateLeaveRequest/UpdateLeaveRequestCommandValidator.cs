using FluentValidation;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Features.LeaveRequest.Commands.Shared;

namespace HR.Management.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLeaveRequestCommandValidator(IUnitOfWork unitOfWork)
        {

            this._unitOfWork = unitOfWork;

            Include(new BaseLeaveRequestValidator(unitOfWork));

            RuleFor(p => p.Id)
                    .NotNull()
                    .MustAsync(LeaveRequestMustExist)
                    .WithMessage("{PropertyName} must be present");
        }

        private async Task<bool> LeaveRequestMustExist(int id, CancellationToken arg2)
        {
            var leaveAllocation = await _unitOfWork.LeaveRequestRepository.GetByIdAsync(id);
            return leaveAllocation != null;
        }

    }
}
