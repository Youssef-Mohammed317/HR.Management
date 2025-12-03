using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace HR.Management.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetAllLeaveTypesQuery : IRequest<IReadOnlyList<LeaveTypeDto>>
    {

    }
}
