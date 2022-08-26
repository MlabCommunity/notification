using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;
using Lapka.Notification.Application.Exceptions.GrpcExceptions;
using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Core.Domain;
using Lapka.Notification.Core.Domain.Entities;

namespace Lapka.Notification.Application.CommandHandlers;

public class SaveConfirmEmailAddressDataCommandHandler : ICommandHandler<SaveConfirmEmailAddressDataCommand>
{
    private readonly IUserDataRepository _userDataRepository;
    private readonly INotificationHistoryRepository _notificationHistoryRepository;

    public SaveConfirmEmailAddressDataCommandHandler(IUserDataRepository userDataRepository, INotificationHistoryRepository notificationHistoryRepository)
    {
        _userDataRepository = userDataRepository;
        _notificationHistoryRepository = notificationHistoryRepository;
    }

    public async Task HandleAsync(SaveConfirmEmailAddressDataCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        if (string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.FirstName) || string.IsNullOrWhiteSpace(command.LastName) || string.IsNullOrWhiteSpace(command.Username)
            || string.IsNullOrWhiteSpace(command.Token) || !Guid.TryParse(command.UserId, out var userId) || Guid.Empty == userId)
        {
            throw new InvalidRequestDataException();
        }

        var user = new UserData(userId, command.Username, command.FirstName, command.LastName, command.Email);

        await _userDataRepository.CreateUserData(user);

        var notification = new NotificationHistory()
        {
            Id = command.Id,
            Type = NotificationType.Email_ConfirmEmailAddress,
            UserEmail = user.Email,
            Subject = user.FirstName + " " + user.LastName,
            Body = command.Token,
            UserId = user.Id
        };

        await _notificationHistoryRepository.CreateNotification(notification);
    }
}