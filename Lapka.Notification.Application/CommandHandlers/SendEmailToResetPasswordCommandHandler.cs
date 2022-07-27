using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Interfaces;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendEmailToResetPasswordCommandHandler : ICommandHandler<SendEmailToResetPasswordCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SendEmailToResetPasswordCommandHandler(INotificationHistoryRepository notificationHistoryRepository)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SendEmailToResetPasswordCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Reset hasła dla emaila {command.Email}, tokenem: {command.Token}"); //sending

        await _notificationHistoryRepository.MarkAsSend(command.Id);
    }
}