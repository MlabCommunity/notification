using Convey.CQRS.Commands;
using Scheme.Application.Exceptions;
using Scheme.Core.Consts;
using Scheme.Core.Entities;
using Scheme.Core.Repositories;

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
        var userData = await _userDataRepository.FindByEmailAsync(command.Email);

       
        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }
        
        var notificationHistory = new NotificationHistory(command.NotificationId, EventType.EMAIL_CHANGE, userData,
            "Confirm your email", command.ConfirmationToken);

        await _notificationHistoryRepository.AddAsync(notificationHistory);
    }
}