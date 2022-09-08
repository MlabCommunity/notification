using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Notification.Application.IncommingEvents;

[Message("identity")]
public record UserDeletedEvent(Guid UserId, string Role) : IEvent;