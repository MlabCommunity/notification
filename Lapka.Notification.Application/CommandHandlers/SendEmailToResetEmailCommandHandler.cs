using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Interfaces;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendEmailToResetEmailCommandHandler : ICommandHandler<SendEmailToResetEmailCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SendEmailToResetEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SendEmailToResetEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Reset maila {command.Email}, tokenem: {command.Token}");

        await _notificationHistoryRepository.MarkAsSend(command.Id);
    }
}