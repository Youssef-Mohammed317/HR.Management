using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.Management.Application.Models.Email;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;

        public ChangeLeaveRequestApprovalCommandHandler(
             IUnitOfWork unitOfWork,  IEmailSender emailSender,
             IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
        {
            this._unitOfWork = unitOfWork;
            this._emailSender = emailSender;
            this._appLogger = appLogger;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _unitOfWork.LeaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }

            leaveRequest.Approved = request.Approved;
            await _unitOfWork.LeaveRequestRepository.UpdateAsync(leaveRequest);

            await _unitOfWork.SaveChangesAsync();

            // if request is approved, get and update the employee's allocations

            try
            {

                // send confirmation email
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
                            $"has been updated.",
                    Subject = "Leave Request Approval Status Updated"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                _appLogger.LogWarning(ex.Message);
            }

            return Unit.Value;
        }
    }
}
