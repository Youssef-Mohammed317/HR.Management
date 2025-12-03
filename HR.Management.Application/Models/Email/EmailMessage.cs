using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Models.Email
{
    public class EmailMessage
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
