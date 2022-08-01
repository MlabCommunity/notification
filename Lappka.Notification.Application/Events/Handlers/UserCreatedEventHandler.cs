using Convey.CQRS.Events;
using Lappka.Notification.Core.Entities;
using Lappka.Notification.Core.Repositories;

namespace Lappka.Notification.Application.Events.Handlers;

internal sealed class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
{
    
    private readonly IUserDataRepository _userDataRepository;
    
    public UserCreatedEventHandler(IUserDataRepository userDataRepository)
    {
        _userDataRepository = userDataRepository;
    }
    
    
    public async Task HandleAsync(UserCreatedEvent @event,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var userData = new UserData(@event.UserId, @event.Email, @event.Username, @event.FirstName, @event.LastName);

        await _userDataRepository.AddAsync(userData);
    }
}