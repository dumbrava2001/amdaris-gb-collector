using System.Net;
using System.Net.Mail;
using AssignmentGarbageCollector.Exceptions;

namespace AssignmentGarbageCollector.Services.Impl;

public class GmailSender : IEmailService
{
    private const string GMAIL_SMTP_SERVER = "smtp.gmail.com";
    private const int GMAIL_SMTP_PORT = 587;
    private const string COMPANY_EMAIL = "YOUR_REAL_EMAIL";
    private const string VERY_SECRET_EMAIL_PASSWORD = "YOUR_APP_PASSWORD";

    public void SendEmail(string to, string subject, string message)
    {
        var mailMessage = CreateMailMessage(to, subject, message);
        try
        {
            using (var smtpServer = new SmtpClient(GMAIL_SMTP_SERVER))
            {
                smtpServer.Port = GMAIL_SMTP_PORT;
                smtpServer.Credentials = new NetworkCredential(COMPANY_EMAIL, VERY_SECRET_EMAIL_PASSWORD);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mailMessage);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error sending email...");
            throw new EmailSenderException("Error sending email using GMail SMTP...", e);
        }
    }

    private static MailMessage CreateMailMessage(string to, string subject, string message)
    {
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(COMPANY_EMAIL);
        mailMessage.To.Add(to);
        mailMessage.Subject = subject;
        mailMessage.Body = message;

        return mailMessage;
    }
}