using Convey.CQRS.Commands;
using Lappka.Notification.Application.Exceptions;
using Lappka.Notification.Core.Repositories;

namespace Lappka.Notification.Application.Commands.Handlers;

internal sealed class SendChangeEmailCommandHandler : ICommandHandler<SendChangeEmailCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SendChangeEmailCommandHandler(IUserDataRepository userDataRepository,
        INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SendChangeEmailCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var userData = await _userDataRepository.FindByEmailAsync(command.Email);

        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }

        var notificationHistory = await _notificationHistoryRepository.GetAsync(command.NotificationId);

        if (notificationHistory is null)
        {
            throw new NotificationHistoryNotFound();
        }

        Console.Write("Email has been sent"); //TODO: Send email

        notificationHistory.NotificationSent();

        await _notificationHistoryRepository.UpdateAsync(notificationHistory);
    }
}