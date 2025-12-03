using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Management.Application.Models.Email
{
    public class EmailSettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string FromAddress { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
    }
}
