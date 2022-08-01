using Convey.CQRS.Commands;
using Lappka.Notification.Application.Exceptions;
using Lappka.Notification.Core.Entities;
using Lappka.Notification.Core.Repositories;
using static Lappka.Notification.Core.Consts.EventType;

namespace Lappka.Notification.Application.Commands.Handlers;

internal sealed class SaveChangeEmailCommandHandler : ICommandHandler<SaveChangeEmailCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SaveChangeEmailCommandHandler(IUserDataRepository userDataRepository,
        INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SaveChangeEmailCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var userData = await _userDataRepository.FindByEmailAsync(command.Email);

        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }

        var notificationHistory = new NotificationHistory(command.NotificationId, EMAIL_CHANGE, userData,
            "Change your email", command.ConfirmationToken);

        await _notificationHistoryRepository.AddAsync(notificationHistory);
    }
}