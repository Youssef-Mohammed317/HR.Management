using HR.Management.Application.Contracts.Persistance;
using HR.Management.Application.Exceptions;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteLeaveTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            var leaveTypeEntity = await unitOfWork.LeaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypeEntity == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            await unitOfWork.LeaveTypeRepository.DeleteAsync(leaveTypeEntity);

            return await unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
