using Convey.CQRS.Commands;
using Lappka.Notification.Application.Exceptions;
using Lappka.Notification.Core.Entities;
using Lappka.Notification.Core.Repositories;
using static Lappka.Notification.Core.Consts.NotificationType;

namespace Lappka.Notification.Application.Commands.Handlers;

internal sealed class SaveResetPasswordCommandHandler : ICommandHandler<SaveResetPasswordCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SaveResetPasswordCommandHandler(IUserDataRepository userDataRepository,
        INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SaveResetPasswordCommand command,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var userData = await _userDataRepository.FindByEmailAsync(command.Email);

        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }
        
        var notificationHistory = new NotificationHistory(command.NotificationId, PASSWORD_RESET, userData,
            "Reset your password", command.ConfirmationToken);

        await _notificationHistoryRepository.AddAsync(notificationHistory);
    }
}