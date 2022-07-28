using Convey.CQRS.Commands;
using Scheme.Application.Exceptions;
using Scheme.Core.Entities;
using Scheme.Core.Repositories;
using static Scheme.Core.Consts.EventType;

namespace Scheme.Application.Commands.Handlers;

public  class SaveConfirmationEmailCommandHandler : ICommandHandler<SaveConfirmationEmailCommand>
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
        var userData = await _userDataRepository.GetByEmailAsync(command.Email);

       
        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }
        
        var notificationHistory = new NotificationHistory(command.NotificationId, EMAIL_CONFIRM, userData,
            command.Email, command.ConfirmationToken);

        await _notificationHistoryRepository.AddAsync(notificationHistory);
    }
}