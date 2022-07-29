using Convey.CQRS.Events;
using Scheme.Application.Exceptions;
using Scheme.Core.Repositories;

namespace Scheme.Application.Events.Handlers;

public class UserUpdatedEventHandler : IEventHandler<UserUpdatedEvent>
{
    private readonly IUserDataRepository _userDataRepository;

    public UserUpdatedEventHandler(IUserDataRepository userDataRepository)
    {
        _userDataRepository = userDataRepository;
    }

    public async Task HandleAsync(UserUpdatedEvent @event,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var userData = await _userDataRepository.FindByIdAsync(@event.UserId);

        if (userData is null)
        {
            throw new UserDataNotFoundException();
        }

        Console.WriteLine(
            "UserUpdated ===============================================================================");
        userData.Update(@event.Email, @event.UserName, @event.FirstName, @event.LastName);

        await _userDataRepository.UpdateAsync(userData);
    }
}