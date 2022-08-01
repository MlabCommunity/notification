using Convey.CQRS.Events;
using Convey.MessageBrokers;

namespace Lapka.Notification.Application.RabbitEvents;

[Message("identity")]
public record UserDeletedEvent(Guid UserId) : IEvent;