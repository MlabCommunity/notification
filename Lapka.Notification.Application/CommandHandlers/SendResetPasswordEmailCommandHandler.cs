using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Interfaces;
using System.Net.Mail;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendResetPasswordEmailCommandHandler : ICommandHandler<SendResetPasswordEmailCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;
    private readonly IMailer _mailer;

    public SendResetPasswordEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository, IMailer mailer)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
        _mailer = mailer;
    }

    public async Task HandleAsync(SendResetPasswordEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Reset hasła dla emaila {command.Email}, tokenem: {command.Token}");
        _mailer.SendMail(new MailMessage()
        {
            Body = $"Zmień hasło tokenem: {command.Token}.",
            To = { $"{command.Email}" },
            Subject = "Reset hasła",
            IsBodyHtml = true
        });

        await _notificationHistoryRepository.MarkAsSend(command.Id);
    }
}