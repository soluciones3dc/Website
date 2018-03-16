using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IIIDC.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _EmailConfig;
        public EmailSender(IOptions<EmailConfig> emailConfig)
        {
            _EmailConfig = emailConfig.Value;
        }

        public async Task SendEmailAsync(string fromEmail, string subject, string name, 
            string message, string phone)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, name);
            var subject_mail = subject;
            var to = new EmailAddress("soluciones3dc@outlook.es","ContactForms");
            var htmlContent = "<p>" + message + "</p>" + 
                              "<br/>" +
                              "<strong> mi numero de telefono es "+phone +"</strong>";
           
          
            var msg = MailHelper.CreateSingleEmail(from, to, subject_mail, "", htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
