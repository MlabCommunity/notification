using System.Net;
using System.Net.Mail;
using Lapka.Notification.Application.Interfaces;

namespace Lapka.Notification.Infrastructure.MailClient;

internal sealed class Mailer : IMailer
{
    private readonly MailerOptions _options;

    public Mailer(MailerOptions options)
    {
        _options = options;
    }

    public void SendMail(MailMessage message)
    {
        var smtpClient = new SmtpClient(_options.Server, _options.Port)
        {
            EnableSsl = _options.EnableSsl,
            Credentials = new NetworkCredential(_options.Username, _options.Password),
        };

        message.From = new MailAddress(_options.Username, _options.SenderName);

        using (smtpClient)
        {
            smtpClient.Send(message);
        }
    }
}