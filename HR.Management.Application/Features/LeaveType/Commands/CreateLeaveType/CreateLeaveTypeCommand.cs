using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommand : IRequest<int> // int is the type of id
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
