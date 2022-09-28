using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Interfaces;
using System.Net.Mail;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendResetEmailAddressEmailCommandHandler : ICommandHandler<SendResetEmailAddressEmailCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;
    private readonly IMailer _mailer;

    public SendResetEmailAddressEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository, IMailer mailer)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
        _mailer = mailer;
    }

    public async Task HandleAsync(SendResetEmailAddressEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Reset maila {command.Email}, tokenem: {command.Token}");
        _mailer.SendMail(new MailMessage()
        {
            Body = $"Zmień email tokenem: {command.Token}.",
            To = { $"{command.Email}" },
            Subject = "Reset Adresu Email",
            IsBodyHtml = true
        });

        await _notificationHistoryRepository.MarkAsSend(command.Id);
    }
}