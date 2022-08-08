using Convey.CQRS.Commands;
using Lappka.Notification.Application.Exceptions;
using Lappka.Notification.Core.Consts;
using Lappka.Notification.Core.Entities;
using Lappka.Notification.Core.Repositories;

namespace Lappka.Notification.Application.Commands.Handlers;

internal sealed class SaveConfirmationEmailCommandHandler : ICommandHandler<SaveConfirmationEmailCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SaveConfirmationEmailCommandHandler(IUserDataRepository userDataRepository,
        INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SaveConfirmationEmailCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var userData = await _userDataRepository.FindByEmailAsync(command.Email);
        
        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }

        var notificationHistory = new NotificationHistory(command.NotificationId, NotificationType.EMAIL_CHANGE, userData,
            "Confirm your email", command.ConfirmationToken);

        await _notificationHistoryRepository.AddAsync(notificationHistory);
    }
}