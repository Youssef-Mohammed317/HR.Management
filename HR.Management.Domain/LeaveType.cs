using HR.Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Domain
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
