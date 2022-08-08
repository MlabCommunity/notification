using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Notification.Application.RabbitEvents;

[Message("identity")]
public record UserUpdatedEvent(Guid UserId, string Username, string FirstName, string LastName, string Email) : IEvent;