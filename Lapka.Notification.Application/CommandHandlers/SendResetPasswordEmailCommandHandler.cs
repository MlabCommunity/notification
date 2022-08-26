using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Interfaces;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendResetPasswordEmailCommandHandler : ICommandHandler<SendResetPasswordEmailCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SendResetPasswordEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SendResetPasswordEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Reset hasła dla emaila {command.Email}, tokenem: {command.Token}");

        await _notificationHistoryRepository.MarkAsSend(command.Id);
    }
}