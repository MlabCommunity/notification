using Convey.CQRS.Events;
using Lapka.Notification.Application.Exceptions.RabbitException;
using Lapka.Notification.Application.IncommingEvents;
using Lapka.Notification.Application.Interfaces;

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
            throw new UserNotFoundException(@event.UserId);
        }

        user.Update(@event.FirstName, @event.LastName, @event.Email);

        await _userDataRepository.UpdateUserData(user);
    }
}