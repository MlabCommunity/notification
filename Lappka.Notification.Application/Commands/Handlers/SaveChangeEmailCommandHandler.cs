using Convey.CQRS.Commands;
using Scheme.Application.Exceptions;
using Scheme.Core.Entities;
using Scheme.Core.Repositories;
using static Scheme.Core.Consts.EventType;

namespace Scheme.Application.Commands.Handlers;

public class SaveChangeEmailCommandHandler : ICommandHandler<SaveChangeEmailCommand>
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