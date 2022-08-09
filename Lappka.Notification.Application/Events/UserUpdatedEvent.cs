using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lappka.Notification.Application.Events;

[Message("identity")]
public class UserUpdatedEvent : IEvent
{
    public Guid UserId { get; }
    public string Email { get; }
    public string UserName { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public UserUpdatedEvent(Guid userId, string email, string userName, string firstName, string lastName)
    {
        UserId = userId;
        Email = email;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
    }
}