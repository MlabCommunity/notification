using System.Net.Mail;

namespace Lapka.Notification.Application.Interfaces;

public interface IMailer
{
    void SendMail(MailMessage message);
}