using HR.Management.Application.Features.LeaveRequest.Commands.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest, IRequest<int>
    {
        public string RequestComments { get; set; } = string.Empty;
    }
}
