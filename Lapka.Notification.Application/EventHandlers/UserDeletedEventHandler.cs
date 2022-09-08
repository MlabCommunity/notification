using Convey.CQRS.Events;
using Lapka.Notification.Application.IncommingEvents;
using Lapka.Notification.Application.Interfaces;

namespace Lapka.Notification.Application.EventHandlers;

public class UserDeletedEventHandler : IEventHandler<UserDeletedEvent>
{
    private readonly IUserDataRepository _userDataRepository;

    public UserDeletedEventHandler(IUserDataRepository userDataRepository)
    {
        _userDataRepository = userDataRepository;
    }

    public async Task HandleAsync(UserDeletedEvent @event, CancellationToken cancellationToken = new CancellationToken())
    {
        var user = await _userDataRepository.GetUserDataById(@event.UserId);
        if (user is not null)
        {
            await _userDataRepository.DeleteUserData(user);
        }
    }
}