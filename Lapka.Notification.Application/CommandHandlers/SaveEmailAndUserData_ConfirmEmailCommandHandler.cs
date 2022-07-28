using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Exceptions.GGrpcExceptions;
using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Core.Domain;
using Lapka.Notification.Core.Domain.Entities;

namespace Lapka.Notification.Application.CommandHandlers;

public class SaveEmailAndUserData_ConfirmEmailCommandHandler : ICommandHandler<SaveEmailAndUserData_ConfirmEmailCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SaveEmailAndUserData_ConfirmEmailCommandHandler(IUserDataRepository userDataRepository, INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SaveEmailAndUserData_ConfirmEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        if (command.Email is null || command.FirstName is null || command.LastName is null || command.Username is null
            || command.Token is null || command.UserId == Guid.Empty)
        {
            throw new InvalidRequestDataException();
        }

        var user = new UserData()
        {
            Id = command.UserId,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Username = command.Username
        };

        await _userDataRepository.CreateUserData(user);

        var notification = new NotificationHistory()
        {
            Id = command.Id,
            Type = NotificationType.Email_ConfirmEmail,
            UserEmail = user.Email,
            Subject = user.FirstName + " " + user.LastName + " " + user.Username,
            Body = command.Token,
            UserId = user.Id
        };

        await _notificationHistoryRepository.CreateNotification(notification);
    }
}