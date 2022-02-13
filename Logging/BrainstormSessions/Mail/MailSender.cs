using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BrainstormSessions.Mail
{
    public static class MailSender
    {
        private const string from = "loggingtestsmtp1@mail.ru";

        private const string password = "SdXK5vCtC74NCKn2N5Cp";

        private static MailMessage msg = new MailMessage()
        {
            Subject = "Logging",
            From = new MailAddress(from),
            To = { new MailAddress("loggingtestsmtp2@mail.ru") },

        };

        private static SmtpClient smtp = new SmtpClient()
        {
            Host = "smtp.mail.ru",
            Port = 587,
            UseDefaultCredentials = false,
            EnableSsl = true,
            Credentials = new NetworkCredential(from, password),

        };

        public static void Send(string message)
        {
            msg.Body = message;

            smtp.Send(msg);
        }
    }
}
