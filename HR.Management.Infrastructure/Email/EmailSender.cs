using HR.Management.Application.Contracts.Email;
using HR.Management.Application.Models.Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace HR.Management.Infrastructure.Email
{

    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            this._emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(EmailMessage email)
        {

            var client = new SendGridClient(_emailSettings.ApiKey);

            var from = new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName);

            var to = new EmailAddress(email.To);

            var msg = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

            var response = await client.SendEmailAsync(msg);

            return response.IsSuccessStatusCode;

        }
    }

}