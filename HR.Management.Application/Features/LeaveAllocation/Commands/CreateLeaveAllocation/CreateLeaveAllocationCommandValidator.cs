using FluentValidation;
using HR.Management.Application.Contracts.Persistance;

namespace HR.Management.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeaveAllocationCommandValidator(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

            RuleFor(p => p.LeaveTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .MustAsync(LeaveTypeMustExist).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");

            RuleFor(p => p.Period)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
                .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");

        }

        private async Task<bool> LeaveTypeMustExist(int leaveTypeId, CancellationToken token)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.GetByIdAsync(leaveTypeId);
            return leaveType != null;
        }
    }
}
