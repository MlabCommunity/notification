using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Notification.Application.IncommingEvents;

[Message("identity")]
public record UserCreatedEvent(Guid UserId, string Role, string LoginProvider, string FirstName, string LastName, string ProfilePicture, string Email, string UserName) : IEvent;