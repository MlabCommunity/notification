using Convey.CQRS.Commands;
using Lappka.Notification.Application.Exceptions;
using Lappka.Notification.Core.Repositories;

namespace Lappka.Notification.Application.Commands.Handlers;

internal sealed class SendResetPasswordCommandHandler : ICommandHandler<SendResetPasswordCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SendResetPasswordCommandHandler(IUserDataRepository userDataRepository,
        INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
        
    }
    public async Task HandleAsync(SendResetPasswordCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        var userData = await _userDataRepository.GetByEmailAsync(command.Email);

        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }

        var notificationHistory = await _notificationHistoryRepository.GetAsync(command.NotificationId);

        if (notificationHistory is null)
        {
            throw new NotificationHistoryNotFound();
        }

        Console.Write("Email has been sent");  //TODO: Send email

        notificationHistory.SendNotification(); 

        await _notificationHistoryRepository.UpdateAsync(notificationHistory);
    }
}