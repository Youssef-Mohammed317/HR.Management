using FluentValidation;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Features.LeaveRequest.Commands.Shared;

namespace HR.Management.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeaveRequestCommandValidator(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

            Include(new BaseLeaveRequestValidator(unitOfWork));
        }
    }
}
