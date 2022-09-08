using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Notification.Application.IncommingEvents;

[Message("identity")]
public record UserUpdatedEvent(Guid UserId, string Role, string FirstName, string LastName, string Email) : IEvent;