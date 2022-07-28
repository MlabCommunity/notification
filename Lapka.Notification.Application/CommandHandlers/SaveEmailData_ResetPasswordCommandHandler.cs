using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Exceptions.GGrpcExceptions;
using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Core.Domain;
using Lapka.Notification.Core.Domain.Entities;

namespace Lapka.Notification.Application.CommandHandlers;

public class SaveEmailData_ResetPasswordCommandHandler : ICommandHandler<SaveEmailData_ResetPasswordCommand>
{
    private readonly INotificationHistoryRepository _notificationHistoryRepository;
    private readonly IUserDataRepository _userDataRepository;

    public SaveEmailData_ResetPasswordCommandHandler(INotificationHistoryRepository notificationHistoryRepository, IUserDataRepository userDataRepository)
    {
        _notificationHistoryRepository = notificationHistoryRepository;
        _userDataRepository = userDataRepository;
    }

    public async Task HandleAsync(SaveEmailData_ResetPasswordCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        if (command.Email is "" || command.Token is "")
        {
            throw new InvalidRequestDataException();
        }

        var user = await _userDataRepository.GetUserDataByEmail(command.Email);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var notification = new NotificationHistory()
        {
            Id = command.Id,
            Type = NotificationType.Email_ResetPassword,
            UserEmail = command.Email,
            Subject = user.FirstName + " " + user.LastName + " " + user.Username,
            Body = command.Token,
            UserId = user.Id
        };

        await _notificationHistoryRepository.CreateNotification(notification);
    }
}