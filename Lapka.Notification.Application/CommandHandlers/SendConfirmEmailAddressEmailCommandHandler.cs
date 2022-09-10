using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Interfaces;
using System.Net.Mail;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendConfirmEmailAddressEmailCommandHandler : ICommandHandler<SendConfirmEmailAddressEmailCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;
    private readonly IMailer _mailer;

    public SendConfirmEmailAddressEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository, IMailer mailer)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
        _mailer = mailer;
    }

    public async Task HandleAsync(SendConfirmEmailAddressEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Potwierdzenie maila {command.Email}, tokenem: {command.Token}");
        _mailer.SendMail(new MailMessage()
        {
            Body = $"Potwierdź konto tokenem: {command.Token}.",
            To = { $"{command.Email}" },
            Subject = "Aktywacja konta",
            IsBodyHtml = true
        });

        await _notificationHistoryRepository.MarkAsSend(command.Id);
    }
}