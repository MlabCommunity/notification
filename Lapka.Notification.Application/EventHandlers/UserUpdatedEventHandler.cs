using Convey.CQRS.Events;
using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Application.RabbitEvents;

namespace Lapka.Notification.Application.EventHandlers;

public class UserUpdatedEventHandler : IEventHandler<UserUpdatedEvent>
{
    private readonly IUserDataRepository _userDataRepository;

    public UserUpdatedEventHandler(IUserDataRepository userDataRepository)
    {
        _userDataRepository = userDataRepository;
    }

    public async Task HandleAsync(UserUpdatedEvent @event, CancellationToken cancellationToken = new CancellationToken())
    {
        var user = await _userDataRepository.GetUserDataById(@event.UserId);

        if (user is null)
        {
            throw new Exception("User doesn't exist");
        }

        if(!string.IsNullOrWhiteSpace(@event.Username))
            user.Username = @event.Username;

        if (!string.IsNullOrWhiteSpace(@event.FirstName))
            user.FirstName = @event.FirstName;

        if (!string.IsNullOrWhiteSpace(@event.LastName))
            user.LastName = @event.LastName;

        if (!string.IsNullOrWhiteSpace(@event.Email))
            user.Email = @event.Email;

        await _userDataRepository.UpdateUserData(user);
    }
}