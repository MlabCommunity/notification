using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Interfaces;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendConfirmEmailAddressEmailCommandHandler : ICommandHandler<SendConfirmEmailAddressEmailCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SendConfirmEmailAddressEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SendConfirmEmailAddressEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.WriteLine($"Potwierdzenie maila {command.Email}, tokenem: {command.Token}");

        await _notificationHistoryRepository.MarkAsSend(command.Id);
    }
}