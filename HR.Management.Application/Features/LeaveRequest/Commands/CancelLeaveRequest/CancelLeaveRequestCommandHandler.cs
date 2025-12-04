using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.Management.Application.Models.Email;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;

        public CancelLeaveRequestCommandHandler(
             IUnitOfWork unitOfWork, IEmailSender emailSender,
             IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
        {
            this._unitOfWork = unitOfWork;
            this._emailSender = emailSender;
            this._appLogger = appLogger;
        }

        public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _unitOfWork.LeaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
            {
                throw new NotFoundException(nameof(leaveRequest), request.Id);
            }

            leaveRequest.Cancelled = true;

            await _unitOfWork.LeaveRequestRepository.UpdateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();

            // if already approved, re-evaluate the employee's allocations for the leave type

            try
            {
                // send confirmation email
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D} " +
                            $"has been cancelled successfully.",
                    Subject = "Leave Request Cancelled"
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
