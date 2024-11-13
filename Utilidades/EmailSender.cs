using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _client;

        public EmailSender(ISendGridClient client)
        {
            _client = client;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridMessage msg = new SendGridMessage
            {
                // Cambiar el from con el email dedicado al servicio.
                // From = new EmailAddress("andres.chacon.mora@covao.ed.cr"),
                Subject = subject,
                HtmlContent = htmlMessage
            };
            msg.AddTo(email);
            return _client.SendEmailAsync(msg);
        }
    }
}
