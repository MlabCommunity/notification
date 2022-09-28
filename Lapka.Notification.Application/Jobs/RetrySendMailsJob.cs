using Lapka.Notification.Application.Interfaces;
using System.Net.Mail;

namespace Lapka.Notification.Application.Jobs;

public class RetrySendMailsJob
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;
    private readonly IMailer _mailer;

    public RetrySendMailsJob(INotificationHistoryRepository notificationHistoryRepository, IMailer mailer)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
        _mailer = mailer;
    }

    public async Task<int> Execute()
    {
        var notifications = await _notificationHistoryRepository.GetUnsentNotificationForsubscribers();
        int quantity = 0;

        foreach (var nt in notifications)
        {
            try
            {
                _mailer.SendMail(new MailMessage()
                {
                    Body = nt.Body,
                    To = { nt.UserEmail },
                    Subject = nt.Subject,
                    IsBodyHtml = true
                });

                nt.SetIsSend();
                quantity++;
            }
            catch{}
        }

        if (quantity > 0)
        {
            await _notificationHistoryRepository.UpdateNotifications(notifications);
        }

        return quantity;
    }
}