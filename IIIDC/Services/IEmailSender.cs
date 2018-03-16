using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIIDC.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string name, string message, string phone);
    }
}
