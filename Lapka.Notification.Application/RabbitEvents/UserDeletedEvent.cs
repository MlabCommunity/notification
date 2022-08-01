using Convey.CQRS.Events;

namespace Lapka.Notification.Application.RabbitEvents;

public record UserDeletedEvent(Guid UserId) : IEvent;