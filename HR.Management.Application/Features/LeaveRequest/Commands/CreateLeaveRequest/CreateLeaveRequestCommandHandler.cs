using AutoMapper;
using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Contracts.Logging;
using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using HR.Management.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.Management.Application.Models.Email;
using MediatR;

namespace HR.Management.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;

        public CreateLeaveRequestCommandHandler(IEmailSender emailSender,
            IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
        {
            _emailSender = emailSender;
            _mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._appLogger = appLogger;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Leave Request", validationResult);
            }

            // Get requesting employee's id

            // Check on employee's allocation

            // if allocations aren't enough, return validation error with message

            // Create leave request
            var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);

            await _unitOfWork.LeaveRequestRepository.CreateAsync(leaveRequest);

            await _unitOfWork.SaveChangesAsync();


            try
            {
                // send confirmation email
                var email = new EmailMessage
                {
                    To = string.Empty, /* Get email from employee record */
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                            $"has been submitted successfully.",
                    Subject = "Leave Request Submitted"
                };

                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                _appLogger.LogWarning(ex.Message);
            }


            return leaveRequest.Id;
        }
    }
}
