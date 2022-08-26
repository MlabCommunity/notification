using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Exceptions.GrpcExceptions;
using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Core.Domain;
using Lapka.Notification.Core.Domain.Entities;

namespace Lapka.Notification.Application.CommandHandlers;

public class SaveResetEmailAddressDataCommandHandler : ICommandHandler<SaveResetEmailAddressDataCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SaveResetEmailAddressDataCommandHandler(IUserDataRepository userDataRepository, INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SaveResetEmailAddressDataCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        if (string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.Token) || !Guid.TryParse(command.userId, out var userId))
        {
            throw new InvalidRequestDataException();
        }

        var user = await _userDataRepository.GetUserDataById(userId);
        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var notification = new NotificationHistory()
        {
            Id = command.Id,
            Type = NotificationType.Email_ResetEmailAddress,
            UserEmail = command.Email,
            Subject = user.FirstName + " " + user.LastName + " " + user.Username,
            Body = command.Token,
            UserId = user.Id
        };

        await _notificationHistoryRepository.CreateNotification(notification);
    }
}