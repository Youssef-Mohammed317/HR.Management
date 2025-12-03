using HR.Management.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace HR.Management.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
