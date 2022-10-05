using Convey.CQRS.Events;
using Lapka.Notification.Application.Exceptions.GrpcExceptions;
using Lapka.Notification.Application.IncommingEvents;
using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Core.Domain.Entities;

namespace Lapka.Notification.Application.EventHandlers;

public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
{
    private readonly IUserDataRepository _userDataRepository;

    public UserCreatedEventHandler(IUserDataRepository userDataRepository)
    {
        _userDataRepository = userDataRepository;
    }

    public async Task HandleAsync(UserCreatedEvent @event, CancellationToken cancellationToken = new CancellationToken())
    {
        if (Guid.Empty == @event.UserId || string.IsNullOrWhiteSpace(@event.Email) || string.IsNullOrWhiteSpace(@event.FirstName) || string.IsNullOrWhiteSpace(@event.LastName) || string.IsNullOrWhiteSpace(@event.UserName))
        {
            throw new InvalidRequestDataException();
        }

        if (@event.LoginProvider == "Lapka")
            return;

        var user = await _userDataRepository.GetUserDataById(@event.UserId);
        if (user is not null)
            return;

        user = new UserData(@event.UserId, @event.UserName, @event.FirstName, @event.LastName, @event.Email);
        await _userDataRepository.CreateUserData(user);
    }
}