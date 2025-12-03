using FluentValidation;
using HR.Management.Application.Contracts.Persistance;

namespace HR.Management.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeaveTypeCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Name)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");

            RuleFor(p => p.DefaultDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            RuleFor(p => p)
                .MustAsync(IsUniqueName).WithMessage("Leave type already exists.");

            this._unitOfWork = unitOfWork;
        }

        private async Task<bool> IsUniqueName(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return await _unitOfWork.LeaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
